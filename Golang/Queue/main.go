package main

import "fmt"

type Node struct {
	Data int
	Next *Node
}

type Queue struct {
	First  *Node
	Last   *Node
	Length int
}

func NewQueue() Queue {
	return Queue{}
}

func (q *Queue) Peek() Node {
	return *q.First
}

func (q *Queue) Enqueue(value int) {
	newNode := &Node{Data: value}
	q.Length++

	// Handle case of an empty queue
	if q.Length == 1 {
		q.First = newNode
		q.Last = newNode
		return
	}

	q.Last.Next = newNode
	q.Last = newNode
}

func (q *Queue) Dequeue() Node {
	// Handle empty queue
	if q.Length == 0 {
		return Node{}
	}

	// Handle when it's just one item left
	if q.Length == 1 {
		q.Last = nil
	}

	top := q.First
	q.First = top.Next
	top.Next = nil
	q.Length--
	return *top
}

func (q *Queue) IsEmpty() bool {
	return q.Length == 0
}

// Print prints the elements of the linked list
func (q *Queue) PrintAsArray() {
	current := q.First
	fmt.Print("[")
	for current != nil {
		fmt.Print(current.Data)
		current = current.Next
		if current != nil {
			fmt.Print(", ")
		}
	}
	fmt.Println("]")
}

func main() {
	queue := NewQueue()
	queue.Enqueue(50)
	queue.Enqueue(10)
	fmt.Println("Is Queue Empty?", queue.IsEmpty())
	// currentTop := queue.Peek()
	// fmt.Printf("Current Top: %v, \n", currentTop)
	var lastDequeue = queue.Dequeue()
	queue.PrintAsArray()
	fmt.Printf("First: %v, Last: %v, Length: %v\n", queue.First, queue.Last, queue.Length)
	fmt.Printf("Last Dequeue Item: %v\n", lastDequeue)
}
