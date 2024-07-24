import { HttpInterceptorFn } from "@angular/common/http";

export const AskApiHttpInterceptor: HttpInterceptorFn = (req, next) => {
    const headers = req.headers.set('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFkbWluVXNlciIsInN1YiI6IkFkbWluVXNlciIsImp0aSI6IjQwYWYwOTk1Iiwicm9sZSI6WyJhZG1pbiIsImN1c3RvbWVyIl0sImVtYWlsIjoiY3VzdG9tZXIxQGV4YW1wbGUuY29tIiwiYXVkIjpbImh0dHBzOi8vYXNrLmFwaSIsImh0dHBzOi8vcGF5bWVudC5hcGkiLCJodHRwczovL3dlYmZmIiwiaHR0cHM6Ly9tb2JpbGViZmYiXSwibmJmIjoxNzIxNjM5MTY5LCJleHAiOjE4OTE3MjgwMDAsImlhdCI6MTcyMTYzOTE2OSwiaXNzIjoidHJhbmNoeS50ZWNoIn0.ZWQQx7mYJSzDF894XrUCZXIHCZkhAWJAQx6t91D2YqE');

    req = req.clone({
        url: req.url,
        headers,
        withCredentials: true
    });
    return next(req);
}