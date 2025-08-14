Approach:
Step 1 - Test-Framwork
To solve this problem I started by researching online on how I can identify test methods in assembly files. I realized that most of the test-framworks mark test methods with a tag (test attribute that look like [Test]) in the line that precede to the function decleration. Because I didn't wont my test-runner to rely on existing testing framworks I created a simmple one by myself that include an 
attribute class to mark methods as [Test] and a simple Assert class.

Step 2 - Test Discovery
The next step was to create some simple tests and try to identify the test methods from the assembly.
To manipulate the compiled file I used the Assembly class from the System.Reflection name space, I simply loaded it to a var by using its path and then I could extract all the methods that are marked with test attribute. The Last thing to do was to groupe them by their class (each class represent a different test case).

Step 3 - Execute and Report
Once I had all the test methods the only thing left to do is to execute them. I use 2 nested loops
to go over the groups and the methods, for each method I check if its insatnce method if it does I create instace and invoke it otherwise I just invoke it. while I go over htem I also use a string builder for the report, if the test fails I add to the report the exeception it throwed. in the end I print the string to the console and also to a text file.

Step 4 - BeforeAll and AfterAll
To add this actions I did basiclly the same steps I did for the tests but with different attributes
and invoked them before and after the tests accordinglly. 

Usage:
To use the test-runner add your project to the main folder "test-runner-assignment", add 
"using TestFramework" to your test file and above each test method add [Test].
then run:
"dotnet add YourProject/YourProject.csproj reference TestFramework/TestFramework.csproj" to add it to its refereces.
Or alternativly you can just copy the TestFramework files into your own project.

Once you finish this setup you can run the test-runner from the main folder with this command: 
dotnet run --project TestRunner -- "your assemblly path"

to run the example use:
dotnet build
dotnet run --project TestRunner -- ./MyTests/bin/Debug/net9.0/MyTests.dll
