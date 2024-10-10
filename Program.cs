//*****************************************************************************
//** 962. Maximum Width Ramp    leetcode                                     **
//*****************************************************************************


int maxWidthRamp(int* nums, int numsSize) {
    int* stack = (int*)malloc(numsSize * sizeof(int));
    int stackSize = 0;
    int widestRamp = 0;
    
    // Build a decreasing stack of indices
    for (int i = 0; i < numsSize; i++) {
        if (stackSize == 0 || nums[stack[stackSize - 1]] > nums[i]) {
            stack[stackSize++] = i;
        }
    }
    
    // Traverse the array from right to left
    for (int j = numsSize - 1; j >= 0; j--) {
        // Check if we can form a ramp with the current element nums[j]
        while (stackSize > 0 && nums[stack[stackSize - 1]] <= nums[j]) {
            int i = stack[--stackSize]; // pop the top element
            widestRamp = (widestRamp > (j - i)) ? widestRamp : (j - i);
        }
    }
    
    free(stack);
    return widestRamp;
}