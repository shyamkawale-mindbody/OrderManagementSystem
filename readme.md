#ASP.Net project

## Date:25-Aug-2022

    1. CReate a ASP.NET Core MVC App for following Needs
        - The Application will be used to perform the Identity for USers with following Rules
            - a. When the Appliaiton is Executed and loaded the Administrator Role USer will be created with User NAme and PAssword
                    - e.g. User Name: admin@myapp.com Password: P@ssw0rd_
                    - This will be an Administrator Role User
                    - refer the following link
                        - https://www.webnethelper.com/2022/03/aspnet-core-6-using-role-based-security.html      
            - b. New Roles Can be Created only by Adminsitartor Role
            - c. New User can be directly Created using REgister View
            - d. The User will be able to Log-In only when the Administrator assign role to the user
        - Roles will be
            - Administrator
            - Manager
            - Customer
        - Customer Can Search Products and Can Place Order for the Product
        - Manager Can View The Order and Can Approve it
        - The Order can be made ready for disptach  only by the Administartor

        - Tables
            - Customer
                - CustomerId, NAme, Email, Mobile No, Address
            - Product
                - ProductId, ProductName, CategoryNAme, Unit Price
            - Order
                - OrderId, ProductId, CustomerId, Quantity, Total Price, Order Date, IsOrderApproved, IsOrderDispatched
                - Customer Place Order
                - Manager Can Approve
                - Administrator Can Make it Ready for Dispatch