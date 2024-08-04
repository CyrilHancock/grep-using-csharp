[Regular expressions](https://en.wikipedia.org/wiki/Regular_expression)
(Regexes, for short) are patterns used to match character combinations in
strings. [`grep`](https://en.wikipedia.org/wiki/Grep) is a CLI tool for
searching using Regexes.


The entry point for your `grep` implementation is in `src/Program.cs`.


The usage of `csharpgrep.sh` can be extracted from the provided log. Here's a summary of the commands:

### **Stage #SB5 (Backreferences - Single Backreference)**
1. **Command:** `echo "cat and cat" | ./csharpgrep.sh -E "(cat) and \1"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "cat and dog" | ./csharpgrep.sh -E "(cat) and \1"`
   - **Expected Exit Code:** 1
3. **Command:** `echo "grep 101 is doing grep 101 times" | ./csharpgrep.sh -E "(\w\w\w\w \d\d\d) is doing \1 times"`
   - **Expected Exit Code:** 0
4. **Command:** `echo "$?! 101 is doing $?! 101 times" | ./csharpgrep.sh -E "(\w\w\w \d\d\d) is doing \1 times"`
   - **Expected Exit Code:** 1
5. **Command:** `echo "abcd is abcd, not efg" | ./csharpgrep.sh -E "([abcd]+) is \1, not [^xyz]+"`
   - **Expected Exit Code:** 0
6. **Command:** `echo "efgh is efgh, not efg" | ./csharpgrep.sh -E "([abcd]+) is \1, not [^xyz]+"`
   - **Expected Exit Code:** 1
7. **Command:** `echo "abcd is abcd, not xyz" | ./csharpgrep.sh -E "([abcd]+) is \1, not [^xyz]+"`
   - **Expected Exit Code:** 1
8. **Command:** `echo "this starts and ends with this" | ./csharpgrep.sh -E "^(\w+) starts and ends with \1$"`
   - **Expected Exit Code:** 0
9. **Command:** `echo "that starts and ends with this" | ./csharpgrep.sh -E "^(this) starts and ends with \1$"`
   - **Expected Exit Code:** 1
10. **Command:** `echo "this starts and ends with this?" | ./csharpgrep.sh -E "^(this) starts and ends with \1$"`
    - **Expected Exit Code:** 1
11. **Command:** `echo "once a dreaaamer, always a dreaaamer" | ./csharpgrep.sh -E "once a (drea+mer), alwaysz? a \1"`
    - **Expected Exit Code:** 0
12. **Command:** `echo "once a dremer, always a dreaaamer" | ./csharpgrep.sh -E "once a (drea+mer), alwaysz? a \1"`
    - **Expected Exit Code:** 1
13. **Command:** `echo "once a dreaaamer, alwayszzz a dreaaamer" | ./csharpgrep.sh -E "once a (drea+mer), alwaysz? a \1"`
    - **Expected Exit Code:** 1
14. **Command:** `echo "bugs here and bugs there" | ./csharpgrep.sh -E "(b..s|c..e) here and \1 there"`
    - **Expected Exit Code:** 0
15. **Command:** `echo "bugz here and bugs there" | ./csharpgrep.sh -E "(b..s|c..e) here and \1 there"`
    - **Expected Exit Code:** 1

### **Stage #ZM7 (Alternation)**
1. **Command:** `echo "a cat" | ./csharpgrep.sh -E "a (cat|dog)"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "a dog" | ./csharpgrep.sh -E "a (cat|dog)"`
   - **Expected Exit Code:** 0
3. **Command:** `echo "a cow" | ./csharpgrep.sh -E "a (cat|dog)"`
   - **Expected Exit Code:** 1

### **Stage #ZB3 (Wildcard)**
1. **Command:** `echo "cat" | ./csharpgrep.sh -E "c.t"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "cot" | ./csharpgrep.sh -E "c.t"`
   - **Expected Exit Code:** 0
3. **Command:** `echo "car" | ./csharpgrep.sh -E "c.t"`
   - **Expected Exit Code:** 1

### **Stage #NY8 (Match zero or one times)**
1. **Command:** `echo "cat" | ./csharpgrep.sh -E "ca?t"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "act" | ./csharpgrep.sh -E "ca?t"`
   - **Expected Exit Code:** 0
3. **Command:** `echo "dog" | ./csharpgrep.sh -E "ca?t"`
   - **Expected Exit Code:** 1
4. **Command:** `echo "cag" | ./csharpgrep.sh -E "ca?t"`
   - **Expected Exit Code:** 1

### **Stage #FZ7 (Match one or more times)**
1. **Command:** `echo "caaats" | ./csharpgrep.sh -E "ca+t"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "cat" | ./csharpgrep.sh -E "ca+t"`
   - **Expected Exit Code:** 0
3. **Command:** `echo "act" | ./csharpgrep.sh -E "ca+t"`
   - **Expected Exit Code:** 1

### **Stage #AO7 (End of string anchor)**
1. **Command:** `echo "cat" | ./csharpgrep.sh -E "cat$"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "cats" | ./csharpgrep.sh -E "cat$"`
   - **Expected Exit Code:** 1

### **Stage #RR8 (Start of string anchor)**
1. **Command:** `echo "log" | ./csharpgrep.sh -E "^log"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "slog" | ./csharpgrep.sh -E "^log"`
   - **Expected Exit Code:** 1

### **Stage #SH9 (Combining Character Classes)**
1. **Command:** `echo "sally has 3 apples" | ./csharpgrep.sh -E "\d apple"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "sally has 1 orange" | ./csharpgrep.sh -E "\d apple"`
   - **Expected Exit Code:** 1
3. **Command:** `echo "sally has 124 apples" | ./csharpgrep.sh -E "\d\d\d apples"`
   - **Expected Exit Code:** 0
4. **Command:** `echo "sally has 12 apples" | ./csharpgrep.sh -E "\d\d\d apples"`
   - **Expected Exit Code:** 1
5. **Command:** `echo "sally has 3 dogs" | ./csharpgrep.sh -E "\d \w\w\ws"`
   - **Expected Exit Code:** 0
6. **Command:** `echo "sally has 4 dogs" | ./csharpgrep.sh -E "\d \w\w\ws"`
   - **Expected Exit Code:** 0
7. **Command:** `echo "sally has 1 dog" | ./csharpgrep.sh -E "\d \w\w\ws"`
   - **Expected Exit Code:** 1

### **Stage #RK3 (Negative Character Groups)**
1. **Command:** `echo "apple" | ./csharpgrep.sh -E "[^xyz]"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "banana" | ./csharpgrep.sh -E "[^anb]"`
   - **Expected Exit Code:** 1

### **Stage #TL6 (Positive Character Groups)**
1. **Command:** `echo "a" | ./csharpgrep.sh -E "[abcd]"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "efgh" | ./csharpgrep.sh -E "[abcd]"`
   - **Expected Exit Code:** 1

### **Stage #MR9 (Match alphanumeric characters)**
1. **Command:** `echo "word" | ./csharpgrep.sh -E "\w"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "$!?" | ./csharpgrep.sh -E "\w"`
   - **Expected Exit Code:** 1

### **Stage #OQ2 (Match digits)**
1. **Command:** `echo "123" | ./csharpgrep.sh -E "\d"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "apple" | ./csharpgrep.sh -E "\d"`
   - **Expected Exit Code:** 1

### **Stage #CQ2 (Match a literal character)**
1. **Command:** `echo "dog" | ./csharpgrep.sh -E "d"`
   - **Expected Exit Code:** 0
2. **Command:** `echo "dog" | ./csharpgrep.sh -E "f"`
   - **Expected Exit Code:** 1

This summary covers the commands executed during various stages, along with the expected exit codes.