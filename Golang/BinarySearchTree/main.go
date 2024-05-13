package main

import "fmt"

func main() {
	bst := NewBinarySearchTree()
	bst.Insert(9)
	bst.Insert(4)
	bst.Insert(6)
	bst.Insert(20)
	bst.Insert(15)
	bst.Insert(170)
	bst.Insert(1)

	fmt.Println("Binary Search Tree (In-Order Traversal):")
	bst.Print()

	lookup := BinarySearchTree{Root: bst.Lookup(1)}
	// lookup := bst.Lookup(30)
	// fmt.Printf("Lookup: %v\n", lookup)
	fmt.Print("BST Lookup (In-Order Traversal):")
	lookup.Print()
}

type Node struct {
	Data  int
	Left  *Node
	Right *Node
}

type BinarySearchTree struct {
	Root *Node
}

func NewBinarySearchTree() BinarySearchTree {
	return BinarySearchTree{}
}

func (bst *BinarySearchTree) Insert(value int) {
	// Create the new node
	newNode := &Node{Data: value}

	// Handle root node
	if bst.Root == nil {
		bst.Root = newNode
		return
	}

	// Handle non-root node
	current := bst.Root
	for {
		// Handle left
		if value < current.Data {
			if current.Left == nil {
				current.Left = newNode
				break
			} else {
				current = current.Left
			}
		} else { // Handle Right
			if current.Right == nil {
				current.Right = newNode
				break
			} else {
				current = current.Right
			}
		}
	}
}

func (bst *BinarySearchTree) Lookup(value int) *Node {
	current := bst.Root
	for current != nil {
		if current.Data == value {
			return current
		} else if value < current.Data {
			current = current.Left
		} else {
			current = current.Right
		}
	}

	return nil
}

// func (bst *BinarySearchTree) Remove(value int) {}

// Print prints the elements of the binary search tree in order
func (bst *BinarySearchTree) Print() {
	printInOrder(bst.Root)
	fmt.Println()
}

// Helper function to recursively print the elements of the binary search tree in order
func printInOrder(node *Node) {
	if node != nil {
		printInOrder(node.Left)
		fmt.Printf("%d -> ", node.Data)
		printInOrder(node.Right)
	}
}
