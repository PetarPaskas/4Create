# 4Create

Short explanation:
I've used MSSQL because I was doing this assignment on my laptop - away from home where I only had visual studio installed.
I've setup MSSQL in azure cloud - you can see the username & password in the connection string(appsettings.json)

**/api/companies** : returns a newly created company with a list of its assigned employees
- if an employee exists by an ID/Email; will be assigned. If not; will be created.
- Will require JWT Bearer token issued by the app

**/api/employees** : returns newly created employee with a list of all the companies he's a part of
- if a company exists by and ID or name it will be assigned; it will not be creather otherwise
- Will require JWT Bearer token issued by the app

I didn't do any logging and I didn't write unit tests since I was in a hurry. I've setup some stuff but I had to go :)

JWT:
- JWT token will be issued on **/api/Auth/login** endpoint. Just provide a username which will be added as a claim.
- That same token will be then valid for 60 min which you can verify its validity by sending a get request on the **/api/Auth**. If you get "mjau" as a response; you're good
- There is no refresh token endpoint, you should just request a new one with the same username.
- This application is the issuer

Final:
- It took me about 8 hrs to do all this.

#Note
I just notices my CQRS commands are in the .Domain of the project. That should be in the application layer which is the ".Infrastructure" project. That's kind of a mush of infra/app layer.
