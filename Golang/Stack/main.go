package main

import "fmt"

type Node struct {
	Data int
	Next *Node
}

type Stack struct {
	Top    *Node
	Bottom *Node
	Length int
}

func NewStack() Stack {
	return Stack{}
}

func (s *Stack) Peek() Node {
	return *s.Top
}

func (s *Stack) Push(value int) {
	newNode := &Node{Data: value}
	s.Length++

	// Check if this is the first element in the stack
	if s.Length == 1 {
		s.Top = newNode
		s.Bottom = newNode
		return
	}

	// Prepend Node
	newNode.Next = s.Top
	s.Top = newNode
}

func (s *Stack) Pop() Node {
	// Check if the stack is empty
	if s.Length == 0 {
		return Node{}
	}

	// If there's only one item to be popped, then set tail to nil
	if s.Length == 1 {
		s.Bottom = nil
	}

	top := s.Top
	s.Top = top.Next
	top.Next = nil
	s.Length--
	return *top
}

func (s *Stack) IsEmpty() bool {
	return s.Length == 0
}

// Print prints the elements of the linked list
func (s *Stack) PrintAsArray() {
	current := s.Top
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
	stack := NewStack()
	stack.PrintAsArray()
	fmt.Println("Is Stack Empty?", stack.IsEmpty())
	stack.Push(10)
	stack.Push(20)
	currentTop := stack.Peek()
	stack.Push(50)
	var lastPopped = stack.Pop()
	stack.PrintAsArray()
	fmt.Printf("Top: %v, Bottom: %v, Length: %v\n", stack.Top, stack.Bottom, stack.Length)
	fmt.Printf("Last Popped Item: %v, \n", lastPopped)
	fmt.Printf("Current Top: %v, \n", currentTop)
}
