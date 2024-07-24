import {NgModule} from '@angular/core';
import {ApolloModule, APOLLO_OPTIONS} from 'apollo-angular';
import {InMemoryCache} from '@apollo/client/core';
import {HttpLink} from 'apollo-angular/http';

const uri = 'https://localhost:7040/api/graphql';
export function createApollo(httpLink: HttpLink) {
  return {
    // uri: uri,
    link: httpLink.create({uri, withCredentials: true}), // use this the result of http intercepter being invoked
    cache: new InMemoryCache(),
    headers: {
      Authorization: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluVXNlciIsInN1YiI6IkFkbWluVXNlciIsImp0aSI6IjQwYWYwOTk1Iiwicm9sZSI6WyJhZG1pbiIsImN1c3RvbWVyIl0sImVtYWlsIjoiY3VzdG9tZXIxQGV4YW1wbGUuY29tIiwiYXVkIjpbImh0dHBzOi8vYXNrLmFwaSIsImh0dHBzOi8vcGF5bWVudC5hcGkiLCJodHRwczovL3dlYmZmIiwiaHR0cHM6Ly9tb2JpbGViZmYiXSwibmJmIjoxNzIxNjM5MTY5LCJleHAiOjE4OTE3MjgwMDAsImlhdCI6MTcyMTYzOTE2OSwiaXNzIjoidHJhbmNoeS50ZWNoIn0.ZWQQx7mYJSzDF894XrUCZXIHCZkhAWJAQx6t91D2YqE'
    },
  };
}

@NgModule({
  exports: [ApolloModule],
  providers: [
    {
      provide: APOLLO_OPTIONS,
      useFactory: createApollo,
      deps: [HttpLink],
    },
  ],
})
export class GraphQLModule {}
