// Project Requirements
// 1. Math Game must contain the 4 basic operations
// 2. The divisions should result on INTEGERS ONLY and dividends should go from 0 to 100. Example: Your app shouldn't present the division 7/2 to the user, since it doesn't result in an integer.
// 3. Users should be presented with a menu to choose an operation
// 4. record previous games in a List and there should be an option in the menu for the user to visualize a history of previous games.

using System.Diagnostics;
using CodingProject;

MathGameLogic mathGame = new MathGameLogic();
Random random = new Random();

int firstNumber;
int secondNumber;
int userMenuSelection;
int score = 0;
bool gameOver = false;

static DifficultyLevel ChangeDifficulty()
{
  int userSelection = 0;
  bool correctInput = false;

  Console.WriteLine("Please enter a difficulty number.");
  Console.WriteLine("1 - Easy");
  Console.WriteLine("2 - Medium");
  Console.WriteLine("3 - Hard");

  correctInput = int.TryParse(Console.ReadLine(), out userSelection);

  while (!correctInput)
  {
    Console.WriteLine("Please select a valid option.");
  }

  switch (userSelection)
  {
    case 1:
      return DifficultyLevel.Easy;
    case 2:
      return DifficultyLevel.Medium;
    case 3:
      return DifficultyLevel.Hard;
  }

  return DifficultyLevel.Easy;
}

static void DisplayMathGameQuestion(int firstNumber, int secondNumber, char operation)
{
  Console.WriteLine($"{firstNumber} {operation} {secondNumber} = ?");
}

static int GetMenuSelection(MathGameLogic mathGame)
{
  int menuSelection = -1;
  mathGame.BuildMenu();

  while (menuSelection < 1 || menuSelection > 7)
  {
    while (!int.TryParse(Console.ReadLine(), out menuSelection))
    {
      Console.WriteLine("Please select a valid option 1-8");
    }
  }

  return menuSelection;

}

// async we have to wait for the task
static async Task<int?> GetUserResponse(DifficultyLevel difficulty)
{
  int response = 0;
  int timeout = (int)difficulty;

  Stopwatch stopwatch = new Stopwatch();
  stopwatch.Start();

  Task<string?> getuserInputTask = Task.Run(() => Console.ReadLine());

  try
  {
    string? result = await Task.WhenAny(getuserInputTask, Task.Delay(timeout * 1000)) == getuserInputTask ? getuserInputTask.Result : null;

    stopwatch.Stop();

    if (result != null &&int.TryParse(result, out response))
    {
      Console.WriteLine($"Time taken to answer: {stopwatch.Elapsed.ToString(@"m\::ss\.fff")}");
    }
// something here
    else throw new OperationCanceledException();
  }
  catch (OperationCanceledException)
}

static void PerformOperation(char operation)
{

}

public enum DifficultyLevel
{
  Easy = 45,
  Medium = 30,
  Hard = 15
}
