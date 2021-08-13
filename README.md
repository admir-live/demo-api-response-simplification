### One of the best practices for simplifying API payload responses
This demo shows how to create custom converters for the JSON serialization classes that are provided in the System.Text.Json namespace in order to simplify the response payload which is provided by API Endpoints.

### The domain problem
Nowadays, when we build software products, speed is almost always a top priority. Since the RESTful API concept is one of the most popular today. We must consider a variety of factors, one of which is the payload's size. One technique that fits into this mindset is to use JSON Convertors to compress the payload in order to take a control of serialization and deserialization.

Let's imagine that we have payload like beliwe one:
```
[
   {
      "firstName":"John",
      "lastName":"Doe",
      "userName":{
         "value":"john.doe"
      },
      "budApiMetadata":{
         "budCustomerId":"UserId123",
         "budCustomerSecret":"12345",
         "isRequired":false
      },
      "id":"8b9f305d-6ec2-4ae8-b29b-e653b4ac417e",
      "createdAt":"2021-08-13T10:22:53.1947905",
      "modifiedAt":"2021-08-13T10:22:53.1947909"
   }
]
```

As a result of implementing a JSON conversion strategy, we can obtain the following:
```
[
   {
      "firstName":"John",
      "lastName":"Doe",
      "userName":"My username is: john.doe.",
      "budApiMetadata":"********************12345",
      "id":"8b9f305d-6ec2-4ae8-b29b-e653b4ac417e",
      "createdAt":"2021-08-13T10:22:53.1947905",
      "modifiedAt":"2021-08-13T10:22:53.1947909"
   }
]
```

Which resulted in significant compression while maintaining a readable payload.
