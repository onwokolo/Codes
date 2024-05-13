package main

import "fmt"

type Node struct {
	data int
	next *Node
}

type LinkedList struct {
	head   *Node
	tail   *Node
	length int
}

func NewLinkedList(value int) LinkedList {
	node := Node{
		data: value,
		next: nil,
	}

	return LinkedList{
		head:   &node,
		tail:   &node,
		length: 1,
	}
}

func (ll *LinkedList) Append(value int) {
	newNode := &Node{
		data: value,
		next: nil,
	}

	ll.tail.next = newNode
	ll.tail = newNode
	ll.length++
}

func (ll *LinkedList) Prepend(value int) {
	newNode := &Node{
		data: value,
		next: ll.head,
	}
	ll.head = newNode
	ll.length++
}

func (ll *LinkedList) TraverseToIndex(index int) *Node {
	count := 0
	current := ll.head
	for current != nil && index != count {
		count++
		current = current.next
	}

	return current
}

func (ll *LinkedList) Insert(index, value int) {
	// Handle special cases
	if index < 1 {
		ll.Prepend(value)
		return
	}
	if index >= ll.length {
		ll.Append(value)
		return
	}

	newNode := &Node{
		data: value,
	}

	previous := ll.TraverseToIndex(index - 1)
	next := previous.next
	previous.next = newNode
	newNode.next = next
	ll.length++
}

func (ll *LinkedList) Remove(index int) {
	// Handle special cases
	if ll.length == 0 || index < 0 || index >= ll.length {
		return
	}

	previous := ll.TraverseToIndex(index - 1)
	var unwanted *Node
	if previous != nil {
		unwanted = previous.next
		previous.next = unwanted.next
	} else {
		unwanted = ll.head
	}
	ll.length--

	// When deleting head
	if index == 0 {
		ll.head = unwanted.next
	}

	// When deleting tail
	if ll.length == index {
		ll.tail = previous
	}
}

func (ll *LinkedList) Reverse() {
	current := ll.head
	ll.head, ll.tail = ll.tail, ll.head
	var prev *Node
	var next *Node

	for current != nil {
		next = current.next
		current.next = prev
		prev = current
		current = next
	}
}

// Print prints the elements of the linked list
func (ll *LinkedList) PrintAsArray() {
	current := ll.head
	fmt.Print("[")
	for current != nil {
		fmt.Print(current.data)
		current = current.next
		if current != nil {
			fmt.Print(", ")
		}
	}
	fmt.Println("]")
}

// Print prints the elements of the linked list
func (ll *LinkedList) Print() {
	current := ll.head
	for current != nil {
		fmt.Printf("%d -> ", current.data)
		current = current.next
	}
	fmt.Println("nil")
}

func main() {
	myLinkedList := NewLinkedList(10)
	myLinkedList.Append(5)
	myLinkedList.Append(16)
	myLinkedList.Prepend(1)
	myLinkedList.Insert(4, 75)
	myLinkedList.PrintAsArray()
	// myLinkedList.Remove(0)
	myLinkedList.Reverse()
	myLinkedList.PrintAsArray()
	fmt.Printf("Head: %v, Tail: %v, Length: %v\n", myLinkedList.head, myLinkedList.tail, myLinkedList.length)
	// fmt.Printf("Value at Index: %v\n", myLinkedList.TraverseToIndex(100))
	// myLinkedList.Print()
	// fmt.Printf("Length: %v\n", myLinkedList.length)
}
