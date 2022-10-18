//for visuals
class Display {
    //initialize class variables
    Generator generator = new Generator();
    Guess guess = new Guess();

    public void DisplayJumper() {
        Console.WriteLine(@" ___");
        Console.WriteLine(@"/___\");
        Console.WriteLine(@"\   /");
        Console.WriteLine(@" \ /");
        Console.WriteLine(@"  O");
        Console.WriteLine(@" /|\");
        Console.WriteLine(@" / \");
        Console.WriteLine(@"^^^^^^^");
    }

    //display the line for the word being guessed
    //display the letters already guessed
    public void DisplayWordLine() {
        for (int i = 0; i != generator.GetWordCount(); i++) {
            if (generator.GetWord([i]) == guess.GetGuess([i])) {

            }
        }
    }
}