using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataStructure.BinarySearchTree<T>;

namespace DataStructure
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;                                                  // 트리의 뿌리 Node
        public Node Root { get { return root; } }                           // Getter & Setter

        public BinarySearchTree()                                           // 이진탐색트리 생성자
        {
            this.root = null;                                               // 최초 생성인 경우 Root는 Null
        }
        public class Node                                                                       // 데이터를 담을 Node 클래스
        {
            private T item;                                                                     // 데이터가 담길 item 변수
            private Node left;                                                                  // 현 노드의 좌측 자식 노드를 담을 노드
            private Node right;                                                                 // 현 노드의 우측 자식 노드를 담을 노드
            private Node parent;                                                                // 현 노드의 부모 노드를 담을 노드

            public T Item { get { return item; } set { item = value; } }                        // Getter & Setter
            public Node Left { get { return left; } set { left = value; } }                     // Getter & Setter
            public Node Right { get { return right; } set { right = value; } }                  // Getter & Setter
            public Node Parent { get { return parent; } set { parent = value; } }               // Getter & Setter

            public Node(T item, Node left, Node right, Node parent)                             // 노드 생성자
            {
                this.item = item;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }

            // 현 노드의 각 상태를 bool 값으로 반환하는 함수들
            public bool IsRootNode { get { return parent == null; } }                           // 이 노드는 루트노드입니까?
            public bool IsLeftChild { get { return parent.left == this; } }                     // 이 노드는 부모노드의 좌측에 위치합니까?
            public bool IsRightChild { get { return parent.right == this; } }                   // 이 노드는 부모노드의 우측에 위치합니까?
            public bool HasNoChild { get { return left == null && right == null; } }            // 이 노드는 자식이 없습니까?
            public bool HasLeftChild { get { return left != null && right == null ; } }         // 이 노드는 좌측 자식만 있습니까?
            public bool HasRightChild { get { return left == null && right != null; } }         // 이 노드는 우측 자식만 있습니까?
            public bool HasBothChild { get { return left != null && right != null; } }          // 이 노드는 자식이 둘 다 있습니까?

        }

        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);                                    // 데이터 생성

            if(this.root == null)                                                               // 현재 Root가 null이라면(현 트리가 텅텅 빈 상태라면)
            {
                this.root = newNode;                                                            // item을 담은 Node를 Root노드로 지정
                return;                                                                         // 함수종료
            }

            Node current = this.root;                                                           // 새로 들어온 값과 비교해줄 노드(current)의 초기 값은 this.root
            
            while(current != null)                                                              // current 의 노드가 Null이 아닌 경우를 조건으로 반복하는 반복문
            {
                // 트리에 넣을 값과 현 노드의 값을 비교
                if (item.CompareTo(current.Item) < 0)                                           // current.item이 item 보다 작다.                                    
                {
                    // 현 노드에 좌측 자식 노드가 있는지 확인
                    if(current.Left != null)                                                    // 좌측 자식 노드가 존재한다.                                      
                    {
                        current = current.Left;                                                 // current의 좌측자식 노드를 비교 노드(current)로 설정
                    } else                                                                      // 좌측 자식 노드가 존재하지 않는다.
                    {
                        current.Left = newNode;                                                 // newNode의 자리를 current의 좌측 자식노드로 지정
                        newNode.Parent = current;                                               // newNode의 부모노드를 current로 지정
                    }
                }else if(item.CompareTo(current.Item) > 0)                                      // current.item이 item 보다 크다.
                {
                    if(current.Right != null)                                                   // 우측 자식 노드가 존재한다.
                    {
                        current = current.Right;                                                // current의 우측자식 노드를 비교 노드(current)로 설정
                    }
                    else                                                                        // 우측 자식 노드가 존재하지 않는다.
                    {
                        current.Right = newNode;                                                // newNode의 자리를 current의 우측 자식노드로 지정
                        newNode.Parent = current;                                               // newNode의 부모노드를 current로 지정
                    }
                }
                else
                {
                    return;                                                                     // 함수종료
                }
            }
        }

        public bool Remove(T item)
        {
            Node findNode = FindNode(item);                                                     // 우선 삭제하고자 하는 노드가 있는지 item을 매개변수로 FindNode 호출

            if(findNode == null)                                                                // 존재하지 않음
            {
                return false;                                                                   // false 반환
            } else
            {
                ErageNode(findNode);                                                            // 노드 삭제 함수인 ErageNode 호출
                return true;                                                                    // true 반환
            }
        }

        public void ErageNode(Node node)
        {
            if (node.HasNoChild)                                                                // 지우고자 하는 노드가 자식이 없는 경우
            {
                if (node.IsLeftChild)                                                           // 지우고자 하는 노드가 부모로부터 좌측자식인 경우
                {
                    node.Parent.Left = null;                                                    // 부모가 가르키는 좌측 노드를 Null로 
                }else if (node.IsRightChild)                                                    // 지우고자 하는 노드가 부모로부터 우측자식인 경우
                {
                    node.Parent.Right = null;                                                   // 부모가 가르키는 우측 노드를 Null로
                }else if (node.IsRootNode)                                                      // 지우고자 하는 노드가 루트 노드인 경우
                {
                    node = null;                                                                // node를 null로 바꿔준다.
                }
            }else if (node.HasLeftChild || node.HasRightChild)                                  // 지우고자 하는 노드가 하나의 자식만 있는 경우
            {
                Node parent = node.Parent;                                                      // 각 노드를 이어주기 위해 지우고자 하는 노드의 부모 노드를 담는 변수
                Node child = node.HasLeftChild ? node.Left : node.Right;                        // 각 노드를 이어주기 위해 지우고자 하는 노드의 자식 노드를 담는 변수

                if (node.IsLeftChild)                                                           // 지우고자 하는 노드가 부모의 좌측에 위치한 노드라면 
                {
                    node.Parent.Left = child;                                                   // 부모의 좌측노드에 Child를 넣어주고
                    child.Parent = parent;                                                      // Child의 부모노드에 지우고자 하는 노드의 부모 노드를 넣어준다
                } else if (node.IsRightChild)                                                   // 지우고자 하는 노드가 부모의 우측에 위치한 노드라면 
                {                                       
                    node.Parent.Right = child;                                                  // 부모의 우측노드에 Child를 넣어주고
                    child.Parent = parent;                                                      // Child의 부모노드에 지우고자 하는 노드의 부모 노드를 넣어준다
                } else if (node.IsRootNode)                                                     // 지우고자 하는 노드가 Root노드라면
                {
                    this.root = child;                                                          // 현 트리의 Root를 Child 노드로 바꿔주고
                    child.Parent = null;                                                        // 그 Child 노드의 부모 노드를 Null로 바꿔준다.
                }
            }else if (node.HasBothChild)                                                        // 지우고자 하는 노드가 좌/우측 모두 자식이 있는 경우
            {
                /* 지우고자 하는 노드가 두개의 자식 값을 가지고 있는 경우
                 * 노드를 '삭제'한다기 보단 해당 노드의 위치에
                 * 지우고자 하는 노드의 값보단 작지만 가장 차이가 적은 값을 가지고 있는 노드를
                 * 복사해주고, 복사에 쓰인 노드를 삭제(null 처리)해줘야한다. 
                 */
                Node replaceNode = node.Left;

                while(replaceNode != null)                                                      // 지우고자 하는 노드보다 적은 값을 가진 좌측 노드로 반복문을 실행
                {
                    replaceNode = replaceNode.Right;                                            // replaceNode는 반복문이 실행되면서 계속해서 지우고자한 노드의 좌측 자식의 '우측자식'들을 탐색하게 됨
                }
                node.Item = replaceNode.Item;                                                   // 지우고자 한 노드가 있던 자리에 replaceNode의 Item을 넣으면서 복사 완료
                ErageNode(replaceNode);                                                         // 이제 복사를 마친 replaceNode를 삭제하기 위한 ErageNode를 재귀호출 한다.
            }
        }

        public bool TryGetValue(T item, out T outValue)
        {
            Node findNode = FindNode(item);                                                 // item(값)으로 노드를 검색하는 FindNode 함수 호출

            if(findNode == null)                                                            // 해당 값으로 노드가 존재하지 않는다.
            {
                outValue = default(T);                                                      // 자료형의 기본값과
                return false;                                                               // false 반환
            } else
            {
                outValue = findNode.Item;                                                   // 검색 된 노드의 Item 값과
                return true;                                                                // true 반환
            }
        }

        public Node FindNode(T item)
        {
            if(this.root == null)                                                           // Root가 Null인경우 비어있는 트리란 뜻
            {
                return null;                                                                // return Null 
            }

            Node current = this.root;
            while(current != null)                                                          // current가 null이 아닌동안 반복되는 조건의 반복문 실행
            {
                if(item.CompareTo(current.Item) < 0)                                        // current.item이 item보다 작다면 좌측 자식노드를 비교노드(current)로
                {
                    current = current.Left;
                }else if(item.CompareTo(current.Item) > 0)                                  // current.item이 item보다 크다면 우측 자식노드를 비교노드(current)로
                {
                    current = current.Right;
                }
                else                                                                        // item과 current.item이 같다!
                {
                    return current;                                                         // current 노드 반환
                }
            }

            return null;                                                                    // 소득없이 반복문을 빠져나왔다면 null을 반환

        }

        public void Print()
        {
            Print(root);
        }

        public void Print(Node node)
        // 이진탐색트리의 구조로 봤을 때
        // 트리의 깊이 상관없이 좌측->우측으로 데이터를 출력해주는 함수는 아래와 같이 구현된다.
        {
            if (node.Left != null)                                                          // 매개변수로 받은 Node에 좌측자식이 있다?
                Print(node.Left);                                                           // 그럼 Node.Left를 매개변수로 Print 함수 재귀호출
            Console.WriteLine(node.Item);                                                   // 매개변수로 받은 Node에 좌측자식이 더이상 없는 경우 값 출력
            if (node.Right != null)                                                         // 출력 후, 매개변수로 받은 Node에 우측 자식이 있다면
                Print(node.Right);                                                          // Node.Right를 매개변수로 Print 함수 재귀호출
        }


    }
}
