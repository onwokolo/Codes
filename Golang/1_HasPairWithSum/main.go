package main

import "fmt"

func main() {
	// fmt.Println(hasPairWithSum([]int{6, 4, 3, 2, 1, 7}, 9))
	fmt.Println(hasPairWithSum2([]int{6, 4, 3, 2, 1, 7}, 9))
}

// Naive Solution
func hasPairWithSum(arr []int, sum int) bool {
	var arrLen = len(arr)
	for i := 0; i < arrLen; i++ {
		for j := i + 1; j < arrLen; j++ {
			if arr[i]+arr[j] == sum {
				return true
			}
		}
	}
	return false
}

// Better Solution
func hasPairWithSum2(arr []int, sum int) bool {
	var mySet = make(map[int]struct{})

	var arrLen = len(arr)
	for i := 0; i < arrLen; i++ {
		_, ok := mySet[arr[i]]
		if ok {
			return true
		}
		mySet[sum-arr[i]] = struct{}{}
	}
	return false
}
