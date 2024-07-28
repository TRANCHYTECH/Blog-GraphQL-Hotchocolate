The source code and configuration related to the Backend are located in the Backend folder.

Here are the instructions to help run the Backend system successfully:

# Install dotnet tools
In the Backend folder, run the command <code>dotnet tool restore</code> to install the tools to support HotChocolate's schema compilation.

# Run databases
In the Backend folder, run the command <code>docker compose up mongo sql redis -d</code>
# Authorization
We use the user-jwts feature of the dotnet tool to simplify the authentication process because it is not in the scope of the article.

One thing to note is that by default this feature only applies to the scope of each project, so each project will have a different Signing key.

Therefore, to ensure that the access token is accepted at the solution level, that is, all projects, we must ensure that all Signing keys are the same.

We can do this by selecting a project to generate access tokens for. Then copy the Signing key from that project's user secret to the other projects. See the appsettings.development.json file for more information.

Here is a sample command to generate access tokens corresponding to the parameters configured in the projects:

```shell
dotnet user-jwts create --name AdminUser --role admin --role customer --issuer tranchy.tech --expires-on 2029-12-12 --audience https://ask.api --audience https://payment.api --audience https://webff --audience https://mobilebff --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress=customer1@example.com
```

# Predefined access tokens with same signing key for all projects
Name: 
AdminUser

Roles: 
[admin, customer]

Token: 
```text
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluVXNlciIsInN1YiI6IkFkbWluVXNlciIsImp0aSI6IjQwYWYwOTk1Iiwicm9sZSI6WyJhZG1pbiIsImN1c3RvbWVyIl0sImVtYWlsIjoiY3VzdG9tZXIxQGV4YW1wbGUuY29tIiwiYXVkIjpbImh0dHBzOi8vYXNrLmFwaSIsImh0dHBzOi8vcGF5bWVudC5hcGkiLCJodHRwczovL3dlYmZmIiwiaHR0cHM6Ly9tb2JpbGViZmYiXSwibmJmIjoxNzIxNjM5MTY5LCJleHAiOjE4OTE3MjgwMDAsImlhdCI6MTcyMTYzOTE2OSwiaXNzIjoidHJhbmNoeS50ZWNoIn0.ZWQQx7mYJSzDF894XrUCZXIHCZkhAWJAQx6t91D2YqE</code>
```
# Thứ tự biên dịch các dự án
Ask.Api và Payment.Api

WebBff và MobileBff
# Samples
Queries:
```graphql
query {
  deposits(where: { status: { eq: "Init" } }) {
    nodes {
      id
      questionId
      status
      amount
    }
  }
}
```
```graphql

query getQuestions {
  questions {
    communityShareAgreement
    createdBy
    createdOn
    id
    priorityKey
    status
    supportLevel
    title
    categoryKeys
    questionCategories {
      key
      description {
        value
        key
      }
    }
  }
}
```
```graphql
query getQuestions {
  questions {
    communityShareAgreement
    createdBy
    createdOn
    id
    priorityKey
    status
    supportLevel
    title
    categoryKeys
    questionCategories {
      key
      description {
        value
        key
      }
    }
  }
}
```
Mutations:
```graphql
mutation createQuestion($input: CreateQuestionInput!) {
  createQuestion(input: $input) {
    question {
      categoryKeys
      comment
      communityShareAgreement
      createdBy
      createdOn
      id
      modifiedOn
      priorityKey
      status
      supportLevel
      title
    }
    errors {
      ... on NotFoundCategoryError {
        __typename
        categoryKeys
        message
      }
    }
  }
}
```
createQuestion mutation input
```graphql
{
  "input": {
    "title": "",
    "categoryKeys": [],
    "communityShareAgreement": true,
    "priorityKey": "TODAY",
    "supportLevel": "AGENCY"
  }
}
```
Subscription
```grahql
subscription {
  questionCreated {
    categoryKeys
    communityShareAgreement
    createdBy
    createdOn
    id
    priorityKey
    status
    supportLevel
    title
    questionCategories {
      createdOn
      id
      key
      modifiedOn
    }
  }
}
```