package main

import "fmt"

func main() {
	num := 10
	fmt.Printf("The Fibonacci index value of %v is %v.\n", num, Fibonacci(num))
	fmt.Printf("The Fibonacci2 index value of %v is %v.\n", num, Fibonacci2(num))
}

// Using recursion
func Fibonacci(num int) int {
	if num < 2 { // This handles the base case as well
		return num
	}

	if num < 0 {
		return 0
	}
	if num == 1 {
		return 1
	}
	return Fibonacci(num-2) + Fibonacci(num-1)
}

// Using Iteration
func Fibonacci2(num int) int {
	// Handle special cases
	if num <= 0 {
		return 0
	}
	if num == 1 {
		return 1
	}

	a, b := 0, 1
	for i := 2; i <= num; i++ {
		a, b = b, a+b
	}
	return b
}
