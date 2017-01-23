Explanation of test scripts:

Good Scripts:
1. Default provided script
2. Wrong coins loaded should affect change
3. Loaded coins cannot match change value should short change
4. Machine can be reconfigured to accept different pops

Must check:
Check bank, and pop and coins slots are empty after teardown
In limbo value after no valid selection made (i.e. 40c inserted) - this value should not be included in teardown
If not enough money, nothing should happen (still has credit)
If not enough pop, nothing should happen (still has credit)
Check short changing due to no change
Check short changing due to invalid denominations (i.e. 33c with only 5c coins)
Check short chaning due to invalid denominations (i.e. 50c with only 100c coins)

Bad Scripts:
1. Default provided script
2. Default provided script
3. Invalid pop name (with number)
4. Invalid coin value (0)
5. Invalid pop name (with symbol)
6. Duplicate coin value
7. More pops than slots
8. Invalid coin value (negative)
9. Invalid pop price (0)
10. Invalid pop price (negative)
