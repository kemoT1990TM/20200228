<img src="../img/logo.png" alt="Chmurowisko logo" width="200" align="right">
<br><br>
<br><br>
<br><br>

# Moving files to S3

## LAB Overview

#### In this lab you will move the web application to S3 bucket.

## Task 1: Preparing security groups.

In this task you will create an S3 bucket to store your website.

1. Download **[CloudFormation template file](./files/s3.yaml)**.
2. In the AWS Management Console, on the **Services** menu, click **CloudFormation**.
3. Click **Create stack**.
4. Choose **Upload a template to Amazon S3** and click **Choose file**.
5. Select the template file you downloaded in step 1.
6. Click **Next**.
7. Enter a name for your stack, e.g. "student-x-stack".
8. Enter an unique name for your public bucket.
9.  Click **Next**.
10. Click **Next**.
11. Click **Create**.
12. Look into **Outputs** of your stack. Save **WebsiteBucketName**, and **DomainName** for further use.

## Task 2: Building and deploying web app using S3

1. Go to your Cloud 9 environment.

```shell
cd app/20200228/
```
2. Pull latest git changes.

```shell
git pull
```
3. Enter the latest frontend directory:
```
cd ~/environment/app/20200228/4/files/Front/
```
4. Install *yarn*:
```
npm install yarn -g
```
5. Install *vue-cli*:
```
npm install -g vue-cli
```
6. Install modules:
```
npm install
```
7. Build:
```
yarn run build
```
8. Use the aws-cli to sync your ./dist folder to your web bucket. 
```
aws s3 sync ./dist s3://YOUR-BUCKET-NAME/
```
9. Check if everything went well by opening your S3 website url in any browser of your choice.
10. Enter your load balncer **DNS Name** as your API endpoint and try using the application.

## Task 3. Turning off frontend Fargate service

1. In the AWS Management Console, on the **Services** menu, click **ECS**.
2. Find yout cluster and click on int name.
3. Select **Services**.
4. Select the frontend service.
5. Click **Delete**.
6. Enter the phrase "delete me" and click **Delete**.


## END LAB

<br><br>

<center><p>&copy; 2020 Chmurowisko Sp. z o.o.<p></center>