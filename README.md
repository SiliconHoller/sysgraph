# System Map #

### Purpose ###

The System Map project is intended to be a live display of complex business processes and infrastructure.  While there are plenty existing tools and standards (Vizio, UML diagrams, etc), they often require a high level of expertise and forethought to use.

### Design Concepts ###

At heart, the entire system is basically a representation of a directed graph, with a few overlaid concepts:


1. Nodes represent discrete "things" (components, servers, software, departments, user groups, etc).  This is a general practice when creating graph structures.
2. Edges represent simple connections between nodes.  This could be as simple as foreign key relationships, update or lookup processes, or standardized actions taken by one node upon another.  This, too, is a standard approach when modeling systems and graph structures.


Node "membership", however, is an additional concept.  In this case, it indicates that a node is grouped under another node, such as a database residing on a server, or a software component that carries out actions as part of a larger system.  In this way, subsystems and their interactions can be extracted, viewed, and modified in accordance with their modeler's point of view.  It also allows directional navigation by looking for "containers" (larger systems in which a particular node is a member) or "residents" (nodes which are classified as being part of this larger node).

For example, a warehouse inventory database would exist as a node, while individual tables would be residents of that database.  At the same time, the shipping department could classify the entire database (or individual tables) as part of their fulfillment system, while the billing department could also classify the transaction tables as part of their ordering system.   In this case, the inventory DB would be "contained" by the fulfillment system and the ordering system, while both systems would classify the inventory database as a "resident".

Processes (and edge "membership") is another concept overlaid on the normal directed graph structure.  Similar to the node membership, a particular interaction could be classified as part of, and necessary to, some larger process.  Just as node membership allows a large system to "contain" other nodes, process membership allows a chain of edges (and their relevant nodes) to constitute a larger whole.

Continuing with the inventory system, address validation from an external source or vendor would be carried out as part of the normal processes.  However, the ordering system and the shipping system both rely on valid addresses to carry out their own functions.  If the business, as a whole, decides to use a different vendor or process to execute this function, then edge "membership" would allow them to see that doing so affects multiple processes.


