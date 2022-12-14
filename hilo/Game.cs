class Game {

    Player player = new Player();

    Score score = new Score(300);

    Deck deck = new Deck();

    Card CurrentCard;

    public Game() {
        CurrentCard = deck.DrawRandomCard();
    }

    public void Play() {

        var keepPlaying = true;
        while (keepPlaying) {

            Console.WriteLine("");
            Console.WriteLine($"The card is: {CurrentCard.Name()}");

            var nextCard = deck.DrawRandomCard();
            var guess = player.Guess();

            if (guess == "h") {
                if (nextCard.IsHigher(CurrentCard)) {
                    score.CurrentScore += 100;
                } else {
                    score.CurrentScore -= 75;
                }

            } else if (guess == "l") {
                if (CurrentCard.IsHigher(nextCard)) {
                    score.CurrentScore += 100;
                } else {
                    score.CurrentScore -= 75;
                }
            }

            Console.WriteLine($"Next card was: {nextCard.Name()}");
            Console.WriteLine($"Yours score is: {score.CurrentScore}");
            CurrentCard = nextCard;

            keepPlaying = player.KeepPlaying();            
        }
    }
}
