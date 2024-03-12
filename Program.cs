namespace HealthApp
{
    /*
    * Author: Fatima Oronia
    * Purpose: Final Project
    *Course: COMP 003
    */


    class Program
    {
        
        // The main entry point for the application.
        // <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Collect user information
            string firstName = GetValidName("Enter your first name: ");
            string lastName = GetValidName("Enter your last name: ");
            int birthYear = GetValidBirthYear();
            char gender = GetValidGender();
            string[] questionnaireResponses = GetQuestionnaireResponses();

            // Display a line division
            Console.WriteLine("\n--------------------------------------------------\n");

            // Display profile summary
            Console.WriteLine("Profile Summary:");
            Console.WriteLine($"Full Name: {lastName}, {firstName}");
            Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
            Console.WriteLine($"Gender: {GetGenderDescription(gender)}");

            // Display questionnaire responses
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("Questionnaire Responses:");
            for (int i = 0; i < questionnaireResponses.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questionnaireResponses[i]}");
            }
        }

        
        // Validates and stores the first or last names entered by the user.
        
        // <param name="prompt">The prompt to display to the user.</param>
        // <returns>The validated first or last name.</returns>
        static string GetValidName(string prompt)
        {
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine().Trim();
            } while (string.IsNullOrEmpty(name) || !IsValidName(name));
            return name;
        }

       
        // Validates the format of a name by checking if it consists only of letters.
       
        // <param name="name">The name to validate.</param>
        // <returns>True if the name is valid, otherwise false.</returns>
        static bool IsValidName(string name)
        {
            foreach (char c in name)
            {
                if (!char.IsLetter(c))
                    return false;    //Checks if the character is not a letter.
            }
            return true;
        }

        
        // Validates and stores the birth year entered by the user.
        
        // <returns>The validated birth year.</returns>
        static int GetValidBirthYear()
        {
            int birthYear;
            do
            {
                Console.Write("Enter your birth year: ");
                while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
                {
                    Console.WriteLine("Invalid input. Please enter a valid birth year.");
                }
            } while (birthYear < 1900 || birthYear > DateTime.Now.Year);
            return birthYear;
        } //int.TryParse()- Tries to change the input string to an integer
          //The out keyword allows he method to return more than one value.
          //The ! operator simply means "not" or "neglet", and it effects the result of the expression.

     
        // Validates and stores the gender entered by the user.
      
        // <returns>The validated gender.</returns>
        static char GetValidGender()
        {
            char gender;
            do
            {
                Console.Write("Enter your gender (M/F/O): ");

                // The purpose of char.TryParse() is to attempt to convert the user input to a character.
                // The purpose of the out keyword is to pass the result of the conversion back to the caller.
                // The purpose of the ! operator is to say no to the result of the condition.

                while (!char.TryParse(Console.ReadLine().ToUpper(), out gender) || (gender != 'M' && gender != 'F' && gender != 'O'))
                {
                    Console.WriteLine("Invalid input. Please enter M for Male, F for Female, or O for Other.");
                }
            } while (gender != 'M' && gender != 'F' && gender != 'O');
            return gender;
        }

       
        // Prompts the user to answer a series of questions and collects their responses.
        
        // <returns>An array containing the responses to the questionnaire.</returns>
        static string[] GetQuestionnaireResponses()
        {
            string[] responses = new string[10];
            Console.WriteLine("Please answer the following questions:");

            string[] questions = {
                "Are you taking any medications at this time?",
                "When was your last menstrual cycle? (If male please ignore)",
                "Any history of addiction?",
                "Any known allergies?",
                "Are there any changes in your health since our last visit?",
                "How often do you exercise on a weekly basis?",
                "Do you smoke or drink?",
                "Are you sexually active?",
                "Would you say that you keep a healthy lifestyle?",
                "How much water are you drinking on a daily basis?"
            };

            for (int i = 0; i < responses.Length; i++)
            {
                Console.Write($"Question {i + 1}: {questions[i]} ");
                responses[i] = GetValidResponse();
            }

            return responses;
        }

   
        // Validates user responses to ensure they are not null or empty.
  
        // <returns>The validated user response.</returns>
        static string GetValidResponse()
        {
            string response;
            do
            {
                response = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Response cannot be empty. Please provide a valid response.");
                }
            } while (string.IsNullOrEmpty(response));
            return response;
        }

        // Gets the description of the gender based on the provided character.
        // <param name="gender">The character representing the gender ('M' for Male, 'F' for Female, 'O' for Other).</param>
        // <returns>The description of the gender.</returns>
        static string GetGenderDescription(char gender)
        {
            switch (gender)
            {
                case 'M':
                    return "Male";
                case 'F':
                    return "Female";
                case 'O':
                    return "Other";
                default:
                    return "Unknown"; //if the provided gender character is not 'M', 'F', or 'O' and such.
            }
        }
    }
}