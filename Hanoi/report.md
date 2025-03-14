# Assignment1 Report

Course: C# Development SS2025 (4 ECTS, 3 SWS)

Student ID: cc231058

BCC Group: B

Name: Tiffany Müller 

## Methodology: 

### Recursion:
- The SolveHanoiRecursive function solves the Tower of Hanoi problem using a 'break problems into subproblems' approach:
    - The base case (n == 1) represents the simplest scenario, where there is only one disk to move.
      - The disk from the firstRod gets moves to the thirdRod (destination).
      - After this move, the DrawHanoiTowers function is called to visualize the current state of the towers.
    - As one can choose more than 1 disk to move (the recursive case: n > 1), the algorithm breaks the problem down by recursively solving for fewer disks.
      - 1st step: moves the top (n - 1) disks from the firstRod to the secondRod:
        - SolveHanoiRecursive(n - 1, firstRod, secondRod, thirdRod, totalDisks)
        - The largest disk stays on the first rod
      - 2nd step: moves the largerst disk from the firstRod to the thirdRod:
        - thirdRod.Push(firstRod.Pop())
        - DrawHanoiTowers visualizes it
      - 3rd step: moves the n - 1 disks from the secondRod to the thirdRod, completing the puzzle:
        - SolveHanoiRecursive(n - 1, secondRod, thirdRod, firstRod, totalDisks)
    - The recursion calls continue to break down the problem until it reaches the base case (n == 1)
      - Once it reaches the base case, the function starts to "unwind" and the larger disks are moved in the correct order.
      - At each step, there is a vizualization through DrawHanoiTowers.
    - The recursive solution keeps breaking the problem into smaller parts, each time solving a smaller version of the problem with one less disk.
  
### Iteration:
- The iterative solution to the Tower of Hanoi problem follows a structured approach
  - The method takes the number of disks (numOfDisks) and the three rods (firstRod, secondRod, and thirdRod) represented as stacks (Stack<int>)
    - a total moves is calculated (totalMoves = 2^n - 1), where n is the # of disks
    - The formula derives from the mathematical solution to the Tower of Hanoi problem, which states that the minimum number of moves required to solve the puzzle with n disks is 2^n - 1
  - If the number of disks is even, the positions of secondRod and thirdRod are switched. 
    - This ensures the correct order of moves between the rods
  - A loop interates through all the totalMoves needed and at each iteration, the current movie is determined based on the binary representation of the move index:
    -  from is calculated: (i & (i - 1)) % 3, identifying the rod from which a disk is being moved.
    -  to is calculated: ((i | (i - 1)) + 1) % 3, identifying the rod to which the disk is being moved.
   - There is a confirmation to determine which disk should be moved:
     - If the destination rod is empty, or if the top disk on the source rod is smaller than the top disk on the destination rod, a move occurs from the source to the destination rod.
     - If the normal move cannot be made, the move is reversed and occurs from the destination rod back to the source rod.
     - It ensures that no disk can be placed on top of a smaller disk
   - Each move is visualized with the DrawHanoiTowers function. 

### Visualization:
- The DrawHanoiTowers method visualizes the current state of the Tower of Hanoi puzzle. 
  - The method takes in the number of disks and the three rods (left, middle, right) as input, each represented by a stack of integers where the disks are stored.
    - It initializes a string array fieldLabels to label the rods and sets a columnWidth based on the number of disks.
  - For each rod, the method creates a list of strings (towerStrings[i]), where each string represents a disk. The width of each disk is calculated based on its size and the disk are represented with the plus symbol
    - The disks are padded with spaces to align them properly and ensure they appear centered when visualized.
  - After preparing the individual disks for each rod, the method ensures that the rods are visually aligned by adding empty space to the top (if needed) so that all rods have the same number of disks (filled with spaces for the empty rods)
  - The disks from each rod are printed row by row, starting from the top disk. 
    - The method prints each disk from the three rods side by side, separated by a divider.
    - After displaying the disks, the method prints a separator line and labels each rod at the bottom ((L), (M), (R)) to indicate their positions.

## Discussion/Conclusion

### Recursive Approach Challenges and Solutions:
One of the main challenges in the recursive implementation was ensuring the correct breakdown of the problem into smaller subproblems. Initially, I struggled with clearly defining the base case and recursive case, particularly understanding the relationships between the rods and the disks as the recursion deepened. To overcome this, I referred to examples on GeeksforGeeks.org and staael.com, and ChatGPT, which provided clear breakdowns of recursive calls and base cases. This helped clarify the recursive flow, making it easier to visualize the movement of disks and the completion of subproblems.

Additionally, ChatGPT provided clarification when I needed help with refining the recursive calls and how they would interact with the state of the rods. By repeatedly testing the function and visualizing the states through the DrawHanoiTowers function, I was able to finetune the logic, ensuring that each disk movement would adhere to the Tower of Hanoi rules.

### Iterative Approach Challenges and Solutions:
During the iterative approach, I struggled primarily with the handling of the special case for even numbers of disks, where the second and third rods needed to be swapped. At first, I wasn't sure how this adjustment affected the overall logic of the solution. It was a lot harder to find examples for the iteration than it was for the recursion. But eventually through GeekforGeeks and ChatGPT, I was able to understand that swapping the rods for an even number of disks ensures the correct sequence of moves, allowing the solution to function correctly.

Additionally, ChatGPT helped me better understand the process of handling the conditions under which the move direction changes. By discussing the logic with ChatGPT, I was able to ensure that the iterative solution was properly accounting for when the move should occur in the reverse direction.

## Reference: 
- Recursion:
  - https://staael.com/blog/tower-of-hanoi
- Iteration:
  - https://www.geeksforgeeks.org/iterative-tower-of-hanoi/?utm
- Stack:
  - https://www.geeksforgeeks.org/implementing-stack-c-sharp/
  - https://www.geeksforgeeks.org/introduction-to-stack-data-structure-and-algorithm-tutorials/
- ChatGPT