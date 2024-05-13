package main

import "fmt"

func main() {
	s := "yoyo master"
	fmt.Println(reverseString(s))
	fmt.Println(reverseStringRecursive(s))
	fmt.Println(reverseStringRecursive2(s))
}

func reverseString(str string) string {
	reversed := ""
	for _, r := range str {
		reversed = string(r) + reversed
	}
	return reversed
}

// My intuition using Recursion
func reverseStringRecursive(str string) string {
	result := ""
	return reverseStringHelper(str, result)
}

func reverseStringHelper(str, result string) string {
	if len(str) == 0 {
		return ""
	}

	return result + string(str[len(str)-1]) + reverseStringHelper(str[:len(str)-1], result)
}

// Andrei's solution using Recursion
func reverseStringRecursive2(str string) string {
	if len(str) == 0 {
		return ""
	}
	return reverseStringRecursive2(str[1:]) + string(str[0])
}
