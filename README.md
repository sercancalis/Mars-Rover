# Mars-Rover
Mars Rover (C# ConsoleApp)
In order to control a rover, NASA sends a simple string of letters. The possible letters are 'L', 'R' and 'M'. 'L' and 'R' makes the rover spin 90 degrees left or right respectively, without moving from its current spot. 'M' means move forward one grid point, and maintain the same heading.

Assume that the square directly North from (x, y) is (x, y+1).
Input and Output Test Input:
5 5
1 2 N 
LMLMLMLMM 
3 3 E
MMRMMRMRRM

Expected Output: 
1 3 N
5 1 E
