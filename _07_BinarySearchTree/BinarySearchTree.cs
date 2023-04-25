using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _07_BinarySearchTree
{
    internal class BinarySearchTree<T> where T : IComparable<T>         // 비교가능한 Item만 사용 가능
    {
        private Node root;                                              // 값을 찾는 기준이되는 Root 노드
        public Node Root { get { return root; } }
        public BinarySearchTree()
        {
            this.root = null;                                           // 생성 때는 root 노드는 없는 상태
        }


        public class Node
        {
            public T item;

            public Node parent;

            public Node left;

            public Node right;

            public Node(T item, Node parent,Node left,Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }

            public bool IsRootNode { get { return parent == null; } }
            public bool IsLeftChild { get { return parent != null && parent.left == this; } }
            public bool IsRightChild { get { return parent != null && parent.right == this; } }
            public bool HasNoChild { get { return left == null && right == null;  } }
            public bool HasLeftChild { get { return left != null && right == null;  } }
            public bool HasRightChild { get { return left == null && right != null; } }
            public bool HasBothChild { get { return left != null && right != null; } }
        }

        public void Add(T item)
        {
            Node newNode = new Node(item, null, null, null);          // 아이템만 매개변수로 전달하여 node생성

            if(this.root == null)                                     // 최초 Add면 root에 추가하고 return
            {
                this.root = newNode;
                return;
            }

            Node current = this.root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0 )                // 비교해서 더 작은 경우 좌측 자식으로 들어감
                {
                    // 비교 노드가 좌측 자식이 있는 경우
                    if(current.left != null)
                    {
                        // 좌측 자식과 또 비교하기 위해 current의 좌측자식으로 설정
                        current = current.left;
                    }   // 비교 노드가 좌측 자식이 없는 경우 
                    else
                    {
                        // 그 자리가 지금 추가가 될 자리
                        current.left = newNode;
                        newNode.parent = current;
                    }
                }else if(item.CompareTo(current.item) > 0)            // 비교해서 더 큰 경우 우측 자식으로 들어감
                {
                    if(current.right != null)
                    {
                        // 우측 자식과 또 비교하기 위해 current의 우측자식으로 설정
                        current = current.right;
                    }
                    else// 비교 노드가 우측 자식이 없는 경우 
                    {
                        // 그 자리가 지금 추가가 될 자리
                        current.right = newNode;
                        newNode.parent = current;
                        return;
                    }
                }
                else                                                  // 똑같은 데이터가 들어온 경우 
                {
                    return;
                }
            }

        }

        /*
        public bool TryGetValue(T item, out T outValue)
        {
            if (root == null)
            {
                outValue = default(T);
                return false;
            }

            Node current = root;
            while(current != null)
            {
                
                if(item.CompareTo(current.item) < 0)                // 현재 노드의 값이 찾고자 하는 값보다 작다
                {
                    // 좌측 자식부터 다시 찾기 시작
                    current = current.left;
                } else if(item.CompareTo(current.item) > 0)         // 현재 노드의 값이 찾고자 하는 값보다 크다
                {
                    //우측 자식부터 다시 찾기 시작
                    current = current.right;
                } else                                              // 두 값이 같은 경우
                {
                    // 값을 찾았다.
                    outValue = current.item;
                    return true;
                }
            }

            // 못찾음
            outValue = default(T);
            return false;
        }
        */

        public bool Remove(T item)
        {
            Node findNode = FindNode(item);

            if(findNode == null)
            {
                return false;
            }
            else
            {
                ErageNode(findNode);
                return true;
            }
        }

        private void ErageNode(Node node)
        {
            // 1.자식의 없는 경우 
            if(node.HasNoChild)
            {
                if (node.IsLeftChild)                           // 이 노드가 좌측 자식이라면
                    node.parent.left = null;
                else if (node.IsRightChild)                     // 이 노드가 우측 자식이라면
                    node.parent.right = null;
                else if (node.IsRootNode)                       // 이 노드가 루트노드라면
                    node = null;

            } else if (node.HasLeftChild || node.HasRightChild) // 2. 자식이 하나가 있는 경우
            {
                Node parent = node.parent;                                          // 이 노드의 부모노드를 참조
                Node child = node.HasLeftChild ? parent.left : parent.right;        // 이 노드의 자식노드를 참조

                if (node.IsLeftChild)
                {
                    parent.left = child;
                    child.parent = parent;
                } else if(node.IsRightChild)
                {
                    parent.right = child;
                    child.parent = parent;
                } else if (node.IsRootNode)
                {
                    root = child;
                    child.parent = null;
                }
            } else if (node.HasBothChild) // 3. 자식이 둘이나 있는 경우 왼쪽 자식 중 가장 큰 값과 데이터를 교환한 후 그 노드를 지워주는 방식으로 대체
            {
                // 좌측 자식으로 가서 우측으로 반복문을 돌려서 지우려는 노드와 가장 가까운 값을 찾아낼 수 있다.
                // 우측 자식으로 가서 좌측으로 반복문을 돌려서 위 동작을 하는 것도 가능함

                Node replaceNode = node.left;                           // 좌측 자식노드
                while(replaceNode.right != null)                        // 우측 자식으로 쭈우욱 내려감
                {
                    replaceNode = replaceNode.right;
                }

                node.item = replaceNode.item;
                ErageNode(replaceNode);
            }
            

            
        }

        public bool TryGetValue(T item, out T outValue)
        {
            Node findNode = FindNode(item);

            if(findNode == null)
            {
                outValue = default(T);
                return false;
            }
            else
            {
                outValue = findNode.item;
                return true;
            }
        }

        private Node FindNode(T item)
        {
            if (root == null)
            {
                return null;
            }

            Node current = root;
            while (current != null)
            {

                if (item.CompareTo(current.item) < 0)                // 현재 노드의 값이 찾고자 하는 값보다 작다
                {
                    // 좌측 자식부터 다시 찾기 시작
                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)         // 현재 노드의 값이 찾고자 하는 값보다 크다
                {
                    //우측 자식부터 다시 찾기 시작
                    current = current.right;
                }
                else                                              // 두 값이 같은 경우
                {
                    // 값을 찾았다.
                    return current;
                }
            }

            // 못찾음
            return null;
        }
        public void Print()
        {
            Print(root);
        }
        public void Print(Node node)
        {
            if (node.left != null)
                Print(node.left);
            Console.WriteLine(node.item) ;
            if(node.right != null)
                Print(node.right);
        }

    }
}
