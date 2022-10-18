//for generating a random word
class Generator {
    //variables
    private string word = "";
    private int wordCount = 0;

    //methods
    public string GetWord() {
        return word;
    }
    public void SetWord() {
        this.word = word ?? "";
    }

    private int CalculateWordCount(string word, int wordCount) {
        wordCount = word.Count();
        return wordCount;
    }
    public int GetWordCount() {
        return wordCount;
    }
    
}