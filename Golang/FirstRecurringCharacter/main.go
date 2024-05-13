package main

import "fmt"

func main() {
	fmt.Println(FirstRecurringCharacter([]int{2, 5, 1, 2, 3, 5, 1, 2, 4}))
	fmt.Println(FirstRecurringCharacter([]int{2, 1, 1, 2, 3, 5, 1, 2, 4}))
	fmt.Println(FirstRecurringCharacter([]int{2, 3, 4, 5}))
}

func FirstRecurringCharacter(arr []int) int {
	var chars = make(map[int]bool)
	for _, num := range arr {
		if chars[num] {
			return num
		}
		chars[num] = true
	}
	return -1
}
