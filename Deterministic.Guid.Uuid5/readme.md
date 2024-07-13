## Deterministic Guid - UUID5
UUID5 is a deterministic UUID that is generated using a namespace and a name.
The namespace is a UUID that is used to generate the UUID5. The name is a string
that is used to generate the UUID5. 

The UUID5 is generated using the SHA1 hash of the namespace and the name.

If you execute this program in DEBUG mode, you run the manual tests, which will generate
an output like this:
```shell
Deterministic Guid (UUID v5)
Initiating manual tests...
Measuring time to generate 1000000 UUIDs...
Done! Elapsed time: 00:00:00.4894596
Testing for collisions...
Done! Found 0 collisions. Elapsed Time: 00:00:27.6787969

Process finished with exit code 0.
```

If you execute this program in RELEASE mode, you run the performance tests, 
which will generate an output like this:

| Method | IterationCount |      Mean |    Error |   StdDev |       Max |    Median | Rank |   Allocated |
|--------|----------------|----------:|---------:|---------:|----------:|----------:|-----:|------------:|
| UuidV4 | 1000000        |  61.34 ms | 0.612 ms | 0.511 ms |  62.05 ms |  61.45 ms |    1 |        50 B |
| UuidV5 | 1000000        | 380.40 ms | 6.388 ms | 5.975 ms | 390.37 ms | 378.38 ms |    2 | 246390000 B |

## Example Usage
```csharp
var userId = 1234;
var namespaceId = Guid.Parse("6ba7b810-9dad-11d1-80b4-00c04fd430c8");

var guid1 = Uuid5.NewGuid(namespaceId, userId);
var guid2 = Uuid5.NewGuid(namespaceId, userId);

// guid1 and guid2 will be the same
``` 