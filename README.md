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

### Documentation ###

Even the best map of an infrastructure is of little use unless there is available documentation.  Even though the overview itself might be obvious and apparent to a view or user (though usually not), the devil, as they say, is in the details.  Address validation, as explained above, may be a simple and important concept to a business, but is it live?  Is it performed in batches?  Is there timing involved?  When is the bill due for this service?  Where do the configuration values need to go?

Typically in large organizations, some of these answers are known to the experts who handle that particular subsystem (possibly even all the answers).  However, if someone is looking at redesigning the entire system, it's important for them to be able to get to the right information quickly.

If the organization is well-managed and well-disciplined, they probably even have a central Document Management System (DMS) that holds this data.  But unless our intrepid redesign team even knows to ask for "address validation" within the DMS, they may miss this very important process.

(And that's not even counting on terminology issues.  In some systems, it might be filed under "customer validation", or "location information", or "shipment preprocessing".  Unless, by design or accident, they happen to talk to the individuals or department who _know_ of this operation's existance and relevance, large-scale mistakes and problems can occur.) 

For this reason, all nodes, edges, and processes can have multiple comments, notes, and document URL's attached to provide additional information.
