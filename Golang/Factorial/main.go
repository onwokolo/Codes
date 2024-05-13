package main

import "fmt"

func main() {
	num := 2
	fmt.Printf("The factorial of %v is: %v.\n", num, factorial(num))
	fmt.Printf("The factorial2 of %v is: %v.\n", num, factorial2(num))
}

func factorial(num int) int {
	if num < 2 {
		return 1
	}
	return num * factorial(num-1)
}

// Using Iteration
func factorial2(num int) int {
	result := 1
	for num >= 2 {
		result *= num
		num--
	}
	return result
}
