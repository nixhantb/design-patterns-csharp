## Interface Segregation Principle (ISP)

The Interface Segregation Principle (ISP) is one of the five SOLID principles of object-oriented design. It states that a class should not be forced to implement interfaces it does not use, and clients should not be forced to depend on interfaces they do not use.

In simpler terms, the ISP encourages creating fine-grained interfaces that are specific to the needs of the clients, rather than having large, monolithic interfaces that cover a wide range of functionalities.

People don’t pay for the thing they don’t need. If we have base interface that has provided us several methods signature with (print, fax and scan) but old printer only supports(print method). So, it is not advised to throw exception for scan and fax method inside the old printer method. But the rule of interface says, you must implement the method signature in the derived class.