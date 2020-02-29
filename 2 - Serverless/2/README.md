

# LAB 2 - Creating Lambda Functions

## LAB Overview

#### This lab will demonstrate:
 * Creating Lambda function
 * Prepating Cloud9 development environment
 * Creating DynamoDB table
 * Deploy frontend application.



## Task 1: Create a simple Lambda function

In this task you will create simple Lambda function and will look into event object.

1. In the AWS Management Console, on the **Services** menu, click **Lambda**.
2. Click **Create function**.
3. Insert a name for your function e.g "YOUR-NAME-LAMBDA".
4. Select "Python 3.6" as a runtime.
5. Select "Choose an existing role" in the Role menu.
6. Select your created in previous lab. "Lambda1-Role" from the "Existing role" menu.
7. Click **Create function**.
8. Download **[simple\_lambda.py][1]** file and paste the file content into lambda function editor.
9. Click **Save** button.
10. Click **Test** button.
11. Download **[simple\_lambda\_test\_payload.json][2]** file and paste the file content into lambda test data editor.
12. Enter a name for "Event name", e.g. "Testevent".
13. Click **Create** button.
14. Click **Test** button.
15. Go to the top of the page and click **Monitoring**.
16. Click **View logs in CloudWatch**.
17. Click on the latest log stream.
18. Look into lambda execution details. Take a look at test data passed to Lambda function as an event.



## Task 2. Prepare Cloud9 environment, import Lambda function and test it locally

In this task you will import Lambda function we’ve just created. Then you'll test it locally.


1. Go to your **Cloud9** Environment
2. Select **AWS Resources** panel. ![AWS Resources](img/aws_resources.png)
3. Unwind **Remote Functions**.
4. Select your Lambda function. Right click on it and select **Import**.
5. Click **Import** on the pop-up.

6. Righ click on imported function. Select **Run** and **Run Local**. ![Run locally](img/run_local.png)
7. As payload enter
``{
    "test" : "blah"
}``
8. Click **Run** button.

## Task 3. Creating a DynamoDB table, a sort key & a secondary index

In this task you will create DynamoDB table and key needed to retrieve data.

1. In the AWS Management Console, on the **Services** menu, click **DynamoDB**.
2. Click **Create table**.
3. Enter a name for your table, e.g. "student-x-table".
4. Name your *Primary key* as "machine_key" and set the type to "String".
5. Check **Add sort key**.
6. Name your "Sort key" as "application_id" and set the type to "String".
7. Uncheck **Use default settings**.
8. Turn off "Auto scaling" by unchecking **Read capacity** and **Write capacity**.
9. Under **Secondary indexes**, click **Add index**.
10. Enter "application_id" as your **Primery key** and set the type to "String".
11. Set "application_id-index" as **Index name**.
12. Click **Add index**.
9. Click **Create**.

## Task 4. Deploy frontend application.

In this task you will setup codepipeline, to deploy fronted application from repository to S3 public bucket that was created in LAB1.

1. Go back to your **Cloud9** environment.
2. In the terminal windo below create a new folder: `` mkdir fronted_app ``
3. Go the the folder: ``cd frontend_app``
4. Download the source code from S3 by typing: ``aws s3 sync s3://chmo-frontend-applab/ ./``
5. Upload the code to the repository:
   * Initiate repository: ``git init``
   * Add repository URL: ``git remote add origin https://git-codecommit.eu-west-1.amazonaws.com/v1/repos/studentX-repository``
   * Add file: ``git add *``
   * Commit: ``git commit -m "first_commit"``
   * Send data to repository: ``git push origin master``
6. In the AWS Management Console, on the **Services** menu, click **CodeCommit**.
7. Select your repository and check if code is there.
8. In the navigation pane on the left, click **Pipeline** and click **Pipelines**.
9. Create a new pipeline by pressin **Create pipeline** button.
10. Enter the name for the pipieline: **StudentX_pipeline**.
11. Leave the rest as default and click **Next**.
12. For **Source provider** select **AWS CodeCommit**.
    * Repository name:  **studentX-repository**,
    * Branch name: **master**,
    * Change detection option: **Amazon CloudWatch Events (recommended)**,
13. In **Build** press **Skip build stage** and confirm by pressing **Skip**.
14. For **Deploy provider** select **Amazon S3**
    * Region: **EU (Ireland)**,
    * Bucket: **select public bucket created in LAB1**,
    * Mark select for: **Extract file before deploy**,
15. Click **Next**.
16. Verify if everything OK and click **Create pipeline**.
17. Wait till deploy will be done.
18. Check if your website is working fine by opening S3 website url (DomainName copied in LAB1 - task 1.) in a browser.
## END LAB

<br><br>


[1]:	simple_lambda.py
[2]:	simple_lambda_test_payload.json