## Open Closed Principle

Any particular class should have single reason to change meaning it should have only one well-defined responsibility or behavior.

SRP means breaking down the functionality into separate classes based on their distinct responsibilities. One class should handle the task of saving strings in a list (e.g., an "ItemList" class with methods for adding, removing, and updating items), while another class should handle the task of saving the list items to a file.txt (e.g., a "FileHandler" class). This way, each class has a single reason to change and is responsible for a specific aspect of the functionality, leading to a more maintainable and modular codebase.

By **separating concerns** in this manner, you not only improve code organization but also make it easier to make changes or enhancements in the future. Changes related to file handling won't impact the logic of adding/removing items from the list, and vice versa, reducing the risk of introducing unintended bugs.

For example, consider a class that handles both user authentication and database connection. If there is a change in the authentication mechanism, it could affect the database connection logic and vice versa. In this case, the class violates the SRP. To adhere to the SRP, you would create separate classes for user authentication and database connection, each with a single responsibility. This way, changes in one area won't affect the other, making the codebase more maintainable and less error-prone.