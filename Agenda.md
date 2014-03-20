# RavenDB

NoSQL?

 ...NotSQL, No-Only-SQL ?


> A NoSQL database provides a mechanism for storage and retrieval of data that employs less constrained consistency models than traditional relational databases. Motivations for this approach include simplicity of design, horizontal scaling and finer control over availability. NoSQL databases are often highly optimized key–value stores intended for simple retrieval and appending operations, with the goal being significant performance benefits in terms of latency and throughput. NoSQL databases are finding significant and growing industry use in big data and real-time web applications. <cite>Wikipedia</cite>

## Facetter af NoSQL

* Schema-free
* Skalerbar
* Ingen relationel model

ref: Martin Fowler - Definition NoSQL [1]

### Databasetyper

* Key/Value
* Column
* Document
* Graph

#### CAP-theorem

* Consistency
* Availability
* Partition tollerance

> "two out of three" concept can be misleading or misapplied <cite>Eric Brewer</cite>

## Hvordan ser Ravnen ud?

* Schema-free
* Fast-reads
* Automagic
* Deployment-muligheder
* Safe-by-default
	* Det er svært at gøre noget "dumt"
		* Limit på antal requests (30)
		* Limit på mængden af data (128/1024)
	* Transactional

## Men hvordan flyver Ravnen så?

* Documenter
	* POCO / JSON
* Collections
* Identifiers
	* string (resource)
	* int, Guid...mv.
* LINQ

## Man skal lette før man kan flyve

#### Hosts

* Debug console
* Windows Service
* IIS
* Embedded
* Cloud

#### Storage
* InMemory
	* Unittest
	* Cache
* Disk

## Så vis da noget kode!

* Connecting
	* DocumentStore
	* DocumentSession
* CRUD
* Query
	* Eventual consistency
		* IndexStore...eventually
		* DocumentStore...immediately (eg. Load)
	* Strings...you wish

### Indexes

* Lucene
* Non-indexed
	* Temp Index
	* Auto Index
* Map / Reduce
	* Simple
	* Multi-map
* Transformations
* Aging
* Maintainance

### Bundles

## Management

* Backup / Restore
* Lock Index

[1]: http://martinfowler.com/bliki/NosqlDefinition.html
