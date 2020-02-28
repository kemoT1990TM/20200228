<img src="../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# DynamoDB

## LAB Overview

#### In this lab you will remove MongoDb code and will use DynamoDB instead of it.

## Task 1: Creating DynamoDB table

In this task you will create DynamoDB table.

1. In the AWS Management Console, on the **Services** menu, click **DynamoDB**.
2. Click **Create table**.
3. Enter a name for your table, e.g. "student-x-table".
4. Name your *Primary key* as "Id" and set the type to "String".
5. Uncheck **Use default settings**.
6. Turn off "Auto scaling" by unchecking **Read capacity** and **Write capacity**.
7. Click **Create**.

## Task 2: Adding permissions to the task role

1. In the AWS Management Console, on the **Services** menu, click **ECS**.
2. Click **Clusters**.
3. Find your cluster and click on its name.
4. Select **Tasks**.
5. Find your task and click on its **Task definition**.
6. Click **Task Role**.
7. Click **Attach policies**.
8. Find **AmazonDynamoDBFullAccess** policy and attach it to the role.
9. Click **Attach policy**.

## Task 3: Deploying new version of the app

1. Working in your Cloud 9 environment, open *~/environment/app/20200228/6/files/Backend/ProjectBackend/Models/Ticket.cs.cs* file. 
2. Replace <YOUR-TABLE-NAME> with your table name and save the file.
3. Working in your Cloud 9 environment, open *~/environment/app/20200228/5/files/Backend/ProjectBackend/controllersUploadController.cs* file from navigation panel on the left.
4. Look for line: ```private readonly string _bucketName = "YOUR-BUCKET-NAME"; ```
5. Replace <YOUR-BUCKET-NAME> with your bucket name you just created and save the file.
6. Build new docker image, tag it and push to the repository.
7. Using Cloud9 terminal, update your service by executing:
```
aws ecs update-service --force-new-deployment --cluster YOUR-CLUSTER-NAME --service YOUR-SERVICE-NAME
```
## END LAB

<br><br>

<center><p>&copy; 2019 Chmurowisko Sp. z o.o.<p></center>
