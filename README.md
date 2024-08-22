# Security Phrase Detection in Customer Support Tickets

## Objective
  Build a minimal web application that fetches customer support ticket history from a mock API, processes the data using a GPT-3.5 Turbo LLM Model, and displays the results in an interface.

## Scope
  The application should:
  1. Fetch mock ticket data from the following mock API endpoint: https://goruen.free.beeceptor.com/tickets-history.
  2. Detect specific phrases and words in the conversation history.
  3. Display the detected messages that have security issue phrases.
  4. Analyze the overall sentiment of the conversation.
  5. Provide a final README file that explains how the application should be run on any machine, and what keys should be inserted in the settings file to make it work (you can overwrite this one).

## Examples of Security Words or Similar Phrases to be Detected
  - My account was hacked
  - My funds are stolen
  - My access was compromised
  - Someone got access to my account
  - I have lost my funds

## Requirements

### Backend
  1. Create a RESTful API using JAVA, C# (preferred), or Python, or any preferred backend library to serve ticket data.
  2. Implement a sentiment analysis function that calls ChatGPT and wraps the conversation in a prompt.
  3. The result of the prompt should detect security words mentioned above and map them to action words to be displayed on the UI, such as "My account was hacked" should yield "Account Hacked".
  4. Hint: You can ask ChatGPT to return the result as a JSON so it will be easier to parse and return it to the UI.

### Frontend
  1. Use React.js, Angular, MVC, or any other frontend library to build a simple but representable interface.
  2. The Home page design is missing intentionally. Create it such that:
  - It displays the list of users fetched from the mock API.
  - Once we click on a user, it should redirect to the ticket page that contains conversations for that user only.
  - Display the following information for each user: user name and ticket count.
  - Implement sorting alphabetically by user name.
  - Implement filtering options by user name and email in the same box.
  3. Your design of the ticket page should adhere to the Figma design: [Figma Design.](https://www.figma.com/design/3UhOy22CSHLL4WBW3vzrR7/ACX-Test-Task)
  4. The Activity Log part requirement has changed. Now it should be named Activity Summary, and it should contain:
    - Instead of VPN, Restricted, labels it should display the detected security words such as "Account Hacked".
    - The digestion and summary of all the activity of the user based on their conversation with the agent (use ChatGPT in the backend).
    - When clicked on, it should open a dropdown similar to the ticket history, showing the conversation in which the security word was detected. It's up to you to show what you think is necessary information in this part.

## Evaluation Criteria

### Technical Skills
  1. The ability to work in ambiguty, to be creative but at the same time solve the main problem.
  2. Effective communication between frontend and backend.
  3. Balancing between working independently and asking the right questions.
  4. Ability to write code that adheres to Clean Architecture.
  5. Bonus: Write it in a Docker file and include instructions in the README file on how to deploy and run it.

### Code Quality
  1. Clean, maintainable, and readable code.
  2. Proper use of version control (Git) and adherence to best practices.
  3. Adherence to SOLID principles.
  4. If you have additional time left after finishing the main functionality, write unit tests for the most important functionality starting from the backend and then the frontend.

## Submission
  - Please create a repository with your name and push your solution to it.
  - Duration: You have from 4 to 6 hours to complete this task.
