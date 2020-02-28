<img src="../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# Moving data to S3

## LAB Overview

#### In this lab you will move the  application files to S3 bucket.


## Task 1: Creating S3 bucket.

In this task you will create an S3 bucket to store your files.

1. Go to your Cloud 9 environment.
2. Create new bucket by executing:
```
aws s3 mb s3://<MY_BUCKET_NAME> --region eu-west-1
```
## Task 2: Updating uploading controller.

1. Working in your Cloud 9 environment, open *~/environment/app/20200228/5/files/Backend/ProjectBackend/controllersUploadController.cs* file from navigation panel on the left.
2. Look for line: ```private readonly string _bucketName = "YOUR-BUCKET-NAME"; ```
3. Replace <YOUR-BUCKET-NAME> with your bucket name you just created and save the file.
4. Build the docker image (for the backend service), tag it and push to the reposutory.

## Task 3: Creating a role for backend ECS task

1. In the AWS Management Console, on the **Services** menu, click **IAM**.
2. Click **Roles**.
3. Click **Create role**.
4. Select **Elastic Container Service** as the service that will use this role.
5. Select **Elastic Container Service Task** as the use case.
6. Click **Next: Permissions**.
7. Find **AmazonS3FullAccess** policy and attach it to the role.
8. Click **Next: Tags**.
9. Click **Next: Review**.
10. Enter a role name, eg. *student-x-ecs-s3-task-role**.
11. Click **Create Role**.

## Task 4: Updating a task definition

1. In the AWS Management Console, on the **Services** menu, click **ECS**.
2. Click **Task Definitions**.
3. Select your backend task definition ald click **Create new revision**.
4. Set the role you created in previous task as a **Task role**.
5. Click **Create**.

## Task 5: Updating the backend service

1. Click **Clusters**.
2. Find your cluster and click on its name.
3. Select **Services**.
4. Select your backend service anc click **Update**.
5. Set **Revision** of **Task definition** to the latest.
6. Select **Force new deployment**.
7. Click **Next step** 3 times.
8. Click **Update Service**.
9. Click **View Service**.
10. Wait for the deployment to be finished and try adding a new ticket with a file attached.


## END LAB

<br><br>

<center><p>&copy; 2019 Chmurowisko Sp. z o.o.<p></center>