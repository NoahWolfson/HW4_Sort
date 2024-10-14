using System.Runtime.InteropServices;

class CircularLinkedList() {

    class Node(int val, Node pointer = null, Node prevPointer = null) {
        public int Val {get; set;} = val;
        public Node NextPointer {get; set;} = pointer;
        public Node PrevPointer {get; set;} = prevPointer;
    }
    private Node head = null;
    private Node tail = null;

    public void addAll(int[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            if (head == null) {
                head = new Node(arr[i]);
                tail = head;
                head.NextPointer = head;
            } else {
                Node newNode = new Node(arr[i]);
                head.PrevPointer = newNode;
                newNode.NextPointer = head;
                newNode.PrevPointer = tail;
                tail.NextPointer = newNode;
                tail = newNode;
            }
        }
        Console.WriteLine();
    } 
    public int Size() {
        int size = 0;
        return GetSize(size, head.NextPointer) + 1;
    }
    private int GetSize(int size, Node node) {
        if (node == head) {
            return size;
        }
        return GetSize(size + 1, node.NextPointer);
    }
    public bool SearchList(int val) {
        Node currNode = head;
        if (head.Val == val) {
            return true;
        }
        return Searcher(val, currNode.NextPointer);
    }
    private bool Searcher(int val, Node node) {
        if (node == head) {
            return false; 
        }
        return val == node.Val ? true : Searcher(val, node.NextPointer);

    }
    public string ToString() {
        string str = "";
        return $"[{StringBuilder(str, head)}]";
    }
    private string StringBuilder(string str, Node node) { 
        return node != tail ? StringBuilder(str += $" {node.Val},", node.NextPointer) : str += $" {node.Val}";
    }
}