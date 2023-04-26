using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 인터페이스 IEquatable 같은지 비교가능한지 .. 
    public class Dictionary<Tkey, TValue> where Tkey : IEquatable<Tkey>
    {
        // Key 값이 똑같은지 판단할 수 있는 자료형만 들어오게끔 IEquatable 인터페이스를 상속함으로서 제약 조건을 걸어준다.

        private const int DefaultCapacity = 1000;                       // 크기를 크게 해쉬테이블은 용량을 포기하고 최적화를 늘려줌

        private struct Entry                                            // 키값과 데이터를 묶어 저장할 구조체 
        {
            public enum State { None, Using, Deleted }

            public State state;
            public int hashCode;
            public Tkey key;                                            // 키값
            public TValue value;                                        // 데이터
        }

        private Entry[] table;                                          // Entry를 담을 테이블(배열)

        public Dictionary()
        {
            table = new Entry[DefaultCapacity];
        }

        public TValue this[Tkey key]
        {
            get
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);
                // key가 일치하는 데이터가 나올때 까지 다음으로 이동
                while (table[index].state == Entry.State.Using)                          
                {
                    if (key.Equals(table[index].key))                                     
                    {
                        return table[index].value;                                  
                    }

                    if (table[index].state != Entry.State.Using)
                    {
                        break;
                    }

                    index = index < table.Length - 1 ? index + 1 : 0;
                }

                throw new InvalidOperationException();

            }

            set
            {
                // 1. key를 index로 해싱
                int index = Math.Abs(key.GetHashCode() % table.Length);
                // key가 일치하는 데이터가 나올때 까지 다음으로 이동
                while (table[index].state == Entry.State.Using)
                {
                    if (key.Equals(table[index].key))
                    {
                        table[index].value = value;
                        return;
                    }

                    if (table[index].state != Entry.State.Using)
                    {
                        break;
                    }

                    index = index < table.Length - 1 ? index + 1 : 0;
                }

                throw new InvalidOperationException();
            }
        }

        public void Add(Tkey key, TValue value)
        {
            // 해싱 방법
            // 1. 나눗셈 법
            // 숫자가 키값으로 왔을때 3921 라는 수가 들어왔다고 가정한다고 하면, 해당 숫자의 index를 가질 수 없다.. 기하급수적으로 큰 숫자이기 때문에..
            // Capacity의 범위를 벗어나기 때문이다.
            // 나눗셈법을 활용하여 숫자의 크기를 줄여 .. index로 지정한다.

            // 2. 자릿수 접기 법
            // 3 9 2 1 라는 수를 받았을 때
            // 3 + 9 + 2 + 1 = 15, index를 15로 지정한다.

            // 3. 문자열이 들어오는 경우
            // 각 문자의 ASCII 또는 유니코드를 (int) 활용해 자릿수 접기하여 index를 지정한다 


            // step.1 key 값을 index 값으로 해싱해줘야함
            int index = Math.Abs(key.GetHashCode() % table.Length);                  // C#에선 GetHashCode 라는 메소드를 지원해준다.
                                                                                     // Math.Abs을 사용하여 값을 절대값으로 결과가 나오게끔 해줌

            // key의 index가 겹치는 경우 (충돌) 사용중이 아닌 index까지 다음으로 이동
            while (table[index].state == Entry.State.Using)                          // 해당 index가 사용중이라면 반복되는 반복문
            {
                if (key.Equals(table[index].key))                                    // Index에 같은 Key값이 위치한 경우..
                {
                    throw new ArgumentException();                                   // C#은 동일한 키값의 Insert를 허용하지 않는다. 이미 존재하는 키 값의 데이터를 바꿔주고싶으면 Add를 사용하지말고 키 값의 데이터를 대입연산으로 바꿔줘야함
                }
                else                                                                 // Hash값은 같지만 key값이 다른 경우
                {
                    index = index < table.Length - 1 ? index + 1 : 0;                   //
                }
            }

            // 사용중이 아닌 index를 발견한 경우 
            table[index].hashCode = key.GetHashCode();
            table[index].key = key;
            table[index].value = value;
            table[index].state = Entry.State.Using;
        }

        public bool Remove(Tkey key)
        {
            int index = Math.Abs(key.GetHashCode() % table.Length);
            // key의 index가 겹치는 경우 (충돌) 사용중이 아닌 index까지 다음으로 이동
            while (table[index].state == Entry.State.Using)                          // 

                if (key.Equals(table[index].key))                                    // 
                {
                    table[index].state = Entry.State.Deleted;                        // 사용/미사용이 아니라 지워졌다고 state를 바꿔줌
                    return true;
                }
                else                                                                 // 
                {
                    index = index < table.Length - 1 ? index + 1 : 0;                   //
                }

            return false;
         }



        }
    }

