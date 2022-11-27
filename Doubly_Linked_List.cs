using System;
class Doubly_Linked_List<T>
{
 private Node<T> head =null;
 public void Add(T value)
 {
    Node<T> node = new Node<T>(value);
    node.SetNext(this.head);
    if(this.head == null)
    {
        this.head = node;
        this.head.SetNext(node);
    }
 }
 private Node<T> tail = null;
}