# Install dotnet tools

# Run databases

# Authorization

<code>
dotnet user-jwts create --name AdminUser --role admin --role customer --issuer tranchy.tech --expires-on 2029-12-12 --audience https://ask.api --audience https://payment.api --audience https://webff --audience https://mobilebff --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress=customer1@example.com
</code>

# Predefined access tokens with same signing key for all projects
Name: AdminUser

Roles: [admin, customer]

Token: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluVXNlciIsInN1YiI6IkFkbWluVXNlciIsImp0aSI6IjQwYWYwOTk1Iiwicm9sZSI6WyJhZG1pbiIsImN1c3RvbWVyIl0sImVtYWlsIjoiY3VzdG9tZXIxQGV4YW1wbGUuY29tIiwiYXVkIjpbImh0dHBzOi8vYXNrLmFwaSIsImh0dHBzOi8vcGF5bWVudC5hcGkiLCJodHRwczovL3dlYmZmIiwiaHR0cHM6Ly9tb2JpbGViZmYiXSwibmJmIjoxNzIxNjM5MTY5LCJleHAiOjE4OTE3MjgwMDAsImlhdCI6MTcyMTYzOTE2OSwiaXNzIjoidHJhbmNoeS50ZWNoIn0.ZWQQx7mYJSzDF894XrUCZXIHCZkhAWJAQx6t91D2YqE

# Query samples

<code>
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
</code>

# Seed data