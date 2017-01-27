
# PetSureWebApi
technical exam
STEPS:
  1. Locate petsuredb.sql file and run the sql script on your local machine
  2. Edit web.config input your local credential and the name of your local server in the "petsureEntities" section
  3. Compile and run.
  4. Copy the base url ex: http://localhost:55434/
  5. Open the PetSureWeb solution
  6. Go to app folder and locate app.js
  7. under myControllerFunction function edit the 'url' variable 
  8. Paste the base url the web api has produced  ex: http://localhost:55434/
  9. Compile and run.
  10. If does'nt automatically navigated to ,please manually go to index.aspx.. http://localhost:55434/index.aspx
  
This project consist of two solutions 
1.web-api
2.web forms
The web-api has a local sql server database (.mdf) that has a petstable. This are the list of pets that will be shown on
the dropdown control in the web forms.

I use annotation routing since im used to this kind of web api routing mechanism.

The web forms is just typical html 5 page yet responsive , i had use bootstrap to make it responsive.
Also functional perfect due to jquery.
I had separated the two projects on different solutions so that i can visualize better if the web-forms are working remotely 
to the web api.
First i assume file upload will be posted directly to the database but upon reading i decided to just make it
save on the local directory under "upload" folder.


Kean Amper 
Applicant
