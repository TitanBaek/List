using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{


    // 남은 과제
    // 해싱과 해시함수에 대한 조사 (해시의 원리와 해싱함수의 효율 등등
    // 해시테이블의 충돌과 충돌해결 방안


    public class Dictionary<TKey, TValue> where TKey : IEquatable<TKey> // Key 값이 똑같은지 서로 비교할 수 있는 자료형만 들어오게끔 IEquatable 인터페이스를 상속함으로서 제약 조건을 걸어준다.
    {
        public const int DefaultCapacity = 1000;                        // 초기 테이블 크기 (1000)
        public struct Entry                                             // index에 담길 데이터들을 묶은 구조체
        {
            public enum State { None,Using,Deleted }                    
            public State state;                                         // 해당 인덱스의 상태를 나타내는 열거형 변수
            public int hashCode;                                        // 데이터의 키 값을 해싱한 해시코드를 담는 변수
            public TKey key;                                            // 데이터의 키 값을 담는 변수
            public TValue value;                                        // 데이터를 담는 변수
        }
        public Entry[] table;                                            // Entry들이 담길 배열
        public Dictionary() { 

            this.table = new Entry[DefaultCapacity];                    // 딕셔너리 생성 시 DefaultCapacity 크기의 배열을 생성
        }

        public TValue this[TKey key]
        {
            get                                                         // Getter 와 Setter
            {                                                           // FindIndex를 호출하여 key 값으로 Index를 받은 후
                int foundIndex = FindIndex(key);                        // Key와 FindIndex가 반환한 Index 자리의 key가 같은지 확인 후
                if (key.Equals(table[foundIndex].key)){
                    return table[foundIndex].value;                     // 같은 key 값이라면 value를 return
                } else
                {
                    throw new InvalidOperationException();              // 아니라면 예외상황 발생
                }
            }
            set
            {
                int foundIndex = FindIndex(key);
                if (key.Equals(table[foundIndex].key))
                {
                   table[foundIndex].value = value;                     // Getter와 동일하나 같은 key 값이라면 index의 value를 value로 바꿔줌
                }
                else
                {
                    throw new InvalidOperationException();              // 같은 key 값이 아닐 시 예외상황 발생
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetIndex(key);                                  // key 값을 해싱하여 index를 반환해주는 함수 호출


            while (table[index].state == Entry.State.Using) {           // 해싱된 index의 위치에 값이 있는 경우 반복문을 통해 값이 들어갈 index의 위치를 증감해줌

                if (key.Equals(table[index].key))                       // 이미 같은 Key값의 데이터가 존재하는 경우 예외상황 발생
                {
                    throw new ArgumentException();

                } else                                                  // key 값은 다르지만 해싱된 index 값이 같은 경우이기 때문에 index를 증감시켜줌
                {
                    index = GetMovedIndex(index);                       // Index 조정 함수 호출
                }            
            }

            // table의 index 위치에 key 값과 value 등의 데이터를 저장하고 state를 using 으로 바꿔줌
            table[index].hashCode = key.GetHashCode();                  
            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
        }

        public bool Remove(TKey key)                                    // 테이블 내의 데이터를 deleted 해주는 Remove 함수
        {
            int foundIndex = FindIndex(key);                            // key 값을 해싱하여 index를 반환해주는 함수 호출

            if (key.Equals(table[foundIndex].key))                      // 굳이 여기서도 key 값을 비교해주는 이유는 FindTable에서 
            {                                                           // 전달 받는 index가 같은 key 값을 가진 index가 아닐 수 있기 때문...
                table[foundIndex].state = Entry.State.Deleted;          // Deleted로 state 를 바꾸고 true 반환
                return true;
            } else
            {
                return false;                                           // 일치하는 key가 테이블에 존재하지 않음 false 반환
            }
        }

        /// <summary>
        /// Getter & Setter와 Remove에서 사용되는 매개변수로 전달받은 key 값으로 
        /// Index를 찾는 함수, 위 3개의 함수에서 반복문이 반복적으로 쓰이는 게 
        /// 가독성이 좋아보이지 않아 따로 함수로 구현하게 되었음
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int FindIndex(TKey key)
        {
            int index = GetIndex(key);                                  // key 값을 해싱하여 index로 반환받는 함수 호출            

            while (table[index].state != Entry.State.None)              // key 값으로 해싱된 index로 key 값과 일치하는 index 자리의 값을 찾는다. 만일 index 위치의 key 값이 매개변수로 받은 key 와 일치하지 않는다면 index를 증감 또는 0으로 만들어주면서 일치하는 키를 찾아 테이블을 순회한다.
            {
                if (table[index].state == Entry.State.Deleted)          // 만약 index의 위치의 데이터가 지워진(Deleted) 상태라면
                {
                    index = GetMovedIndex(index);                       // Index 조정 함수 호출
                    continue;                                           // 반복문 Countinue 
                }

                if (key.Equals(table[index].key))                       // 이부분으로 넘어왔다면 table[index]는 Using인 경우인데, table[index]와 키 값이 같다면
                {
                    break;                                              // Entry 구조체 반환
                }
                else
                {                                                       // key값과 table[index]의 key가 동일하지 않다면 index를 조정하여 위를 반복한다
                    index = GetMovedIndex(index);                       // Index 조정 함수 호출
                }
            }

            return index;                                                // 아무일 없이 반복문을 빠져나온 경우엔 값이 없다는 뜻이므로 null 반환
        }

        /// <summary>
        /// Key 값을 GetHashCode 메소드를 활용하여 해싱한 뒤에
        /// 나누기법을 사용하여 나온 Index 값을 반환해주는 함수
        /// 그렇게 나온 Index는 음수가 될 수 있기 때문에 
        /// Math.Abs 메소드로 절대값으로 변환하여 반환한다.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int GetIndex(TKey key) 
        { 
            return Math.Abs(key.GetHashCode() % table.Length);          

        }

        /// <summary>
        /// while 문에서 index의 위치에 원하는 데이터가 없는 경우
        /// index를 조정해주는 코드를 함수로 따로 빼 가독성을 높이고자 하였음
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetMovedIndex(int index)
        {
            // index 가 현재 table의 크기 보다 작다면 1을 증감 시켜주고, 아니라면 0으로 바꿔줌
            return index = index < table.Length - 1 ? index + 1 : 0;
        }


    }
}
