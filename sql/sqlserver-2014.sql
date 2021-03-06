USE [SystemMap]
GO
/****** Object:  Table [dbo].[attribute_types]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[attribute_types](
	[attrtypeid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
	[iconurl] [nvarchar](1024) NULL,
 CONSTRAINT [pk_attribute_types] PRIMARY KEY CLUSTERED 
(
	[attrtypeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[doc_type]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doc_type](
	[doctypeid] [int] IDENTITY(1,1) NOT NULL,
	[typename] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
	[iconurl] [nvarchar](1024) NULL,
 CONSTRAINT [pk_doctypes] PRIMARY KEY CLUSTERED 
(
	[doctypeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[edge_attributes]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[edge_attributes](
	[attributeid] [int] IDENTITY(1,1) NOT NULL,
	[edgeid] [int] NOT NULL,
	[attrtypeid] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[edgeval] [decimal](10, 5) NOT NULL,
	[descr] [nvarchar](2048) NULL,
 CONSTRAINT [pk_edge_attributes] PRIMARY KEY CLUSTERED 
(
	[attributeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[edge_docs]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[edge_docs](
	[edge_docid] [int] IDENTITY(1,1) NOT NULL,
	[edgeid] [int] NOT NULL,
	[doctypeid] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
	[docurl] [nvarchar](255) NULL,
 CONSTRAINT [pk_edge_docs] PRIMARY KEY CLUSTERED 
(
	[edge_docid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[edges]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[edges](
	[edgeid] [int] IDENTITY(1,1) NOT NULL,
	[edgetypeid] [int] NOT NULL,
	[from_node] [int] NOT NULL,
	[to_node] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
 CONSTRAINT [pk_edges] PRIMARY KEY CLUSTERED 
(
	[edgeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[edgetypes]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[edgetypes](
	[edgetypeid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
	[iconurl] [nvarchar](1024) NULL,
 CONSTRAINT [pk_edgetypes] PRIMARY KEY CLUSTERED 
(
	[edgetypeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[membership_types]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[membership_types](
	[memtypeid] [int] IDENTITY(1,1) NOT NULL,
	[typename] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
	[iconurl] [nvarchar](1024) NULL,
 CONSTRAINT [pk_membershipttypes] PRIMARY KEY CLUSTERED 
(
	[memtypeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[node_attributes]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[node_attributes](
	[attributeid] [int] IDENTITY(1,1) NOT NULL,
	[nodeid] [int] NOT NULL,
	[attrtypeid] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
	[nodeval] [decimal](10, 5) NOT NULL,
 CONSTRAINT [pk_node_attributes] PRIMARY KEY CLUSTERED 
(
	[attributeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[node_docs]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[node_docs](
	[node_docid] [int] IDENTITY(1,1) NOT NULL,
	[nodeid] [int] NOT NULL,
	[doctypeid] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
	[docurl] [nvarchar](255) NULL,
 CONSTRAINT [pk_node_docs] PRIMARY KEY CLUSTERED 
(
	[node_docid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[node_membership]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[node_membership](
	[groupnode_id] [int] NOT NULL,
	[membernode_id] [int] NOT NULL,
	[memtypeid] [int] NULL,
 CONSTRAINT [pk_node_membership] PRIMARY KEY NONCLUSTERED 
(
	[groupnode_id] ASC,
	[membernode_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nodes]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nodes](
	[nodeid] [int] IDENTITY(1,1) NOT NULL,
	[typeid] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
 CONSTRAINT [pk_nodes] PRIMARY KEY CLUSTERED 
(
	[nodeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[nodetypes]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nodetypes](
	[typeid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[iconurl] [nvarchar](1024) NULL,
	[descr] [nvarchar](1024) NULL,
 CONSTRAINT [pk_nodetypes] PRIMARY KEY CLUSTERED 
(
	[typeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[process_docs]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[process_docs](
	[process_docid] [int] IDENTITY(1,1) NOT NULL,
	[processid] [int] NOT NULL,
	[doctypeid] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
	[docurl] [nvarchar](255) NULL,
 CONSTRAINT [pk_process_docs] PRIMARY KEY CLUSTERED 
(
	[process_docid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[process_membership]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[process_membership](
	[processid] [int] NOT NULL,
	[processedge_id] [int] NOT NULL,
	[memtypeid] [int] NULL,
 CONSTRAINT [pk_process_membership] PRIMARY KEY NONCLUSTERED 
(
	[processid] ASC,
	[processedge_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[processes]    Script Date: 1/2/2017 12:02:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[processes](
	[processid] [int] IDENTITY(1,1) NOT NULL,
	[edgetypeid] [int] NOT NULL,
	[from_node] [int] NOT NULL,
	[to_node] [int] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[descr] [nvarchar](2048) NULL,
 CONSTRAINT [pk_processes] PRIMARY KEY CLUSTERED 
(
	[processid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[edge_attributes] ADD  CONSTRAINT [DF_edgeval]  DEFAULT ((1.00)) FOR [edgeval]
GO
ALTER TABLE [dbo].[node_attributes] ADD  CONSTRAINT [DF_nodeval]  DEFAULT ((1.00)) FOR [nodeval]
GO
ALTER TABLE [dbo].[edge_attributes]  WITH CHECK ADD  CONSTRAINT [FK_edgeattr_attrtype] FOREIGN KEY([attrtypeid])
REFERENCES [dbo].[attribute_types] ([attrtypeid])
GO
ALTER TABLE [dbo].[edge_attributes] CHECK CONSTRAINT [FK_edgeattr_attrtype]
GO
ALTER TABLE [dbo].[edge_attributes]  WITH CHECK ADD  CONSTRAINT [FK_edgeattr_node] FOREIGN KEY([edgeid])
REFERENCES [dbo].[edges] ([edgeid])
GO
ALTER TABLE [dbo].[edge_attributes] CHECK CONSTRAINT [FK_edgeattr_node]
GO
ALTER TABLE [dbo].[edge_docs]  WITH CHECK ADD  CONSTRAINT [FK_edgedoc_doctype] FOREIGN KEY([doctypeid])
REFERENCES [dbo].[doc_type] ([doctypeid])
GO
ALTER TABLE [dbo].[edge_docs] CHECK CONSTRAINT [FK_edgedoc_doctype]
GO
ALTER TABLE [dbo].[edge_docs]  WITH CHECK ADD  CONSTRAINT [fk_edgedoc_edge] FOREIGN KEY([edgeid])
REFERENCES [dbo].[edges] ([edgeid])
GO
ALTER TABLE [dbo].[edge_docs] CHECK CONSTRAINT [fk_edgedoc_edge]
GO
ALTER TABLE [dbo].[edges]  WITH CHECK ADD  CONSTRAINT [FK_edge_fromnode] FOREIGN KEY([from_node])
REFERENCES [dbo].[nodes] ([nodeid])
GO
ALTER TABLE [dbo].[edges] CHECK CONSTRAINT [FK_edge_fromnode]
GO
ALTER TABLE [dbo].[edges]  WITH CHECK ADD  CONSTRAINT [FK_edge_tonode] FOREIGN KEY([to_node])
REFERENCES [dbo].[nodes] ([nodeid])
GO
ALTER TABLE [dbo].[edges] CHECK CONSTRAINT [FK_edge_tonode]
GO
ALTER TABLE [dbo].[edges]  WITH CHECK ADD  CONSTRAINT [FK_edge_type] FOREIGN KEY([edgetypeid])
REFERENCES [dbo].[edgetypes] ([edgetypeid])
GO
ALTER TABLE [dbo].[edges] CHECK CONSTRAINT [FK_edge_type]
GO
ALTER TABLE [dbo].[node_attributes]  WITH CHECK ADD  CONSTRAINT [FK_nodeattr_attrtype] FOREIGN KEY([attrtypeid])
REFERENCES [dbo].[attribute_types] ([attrtypeid])
GO
ALTER TABLE [dbo].[node_attributes] CHECK CONSTRAINT [FK_nodeattr_attrtype]
GO
ALTER TABLE [dbo].[node_attributes]  WITH CHECK ADD  CONSTRAINT [FK_nodeattr_node] FOREIGN KEY([nodeid])
REFERENCES [dbo].[nodes] ([nodeid])
GO
ALTER TABLE [dbo].[node_attributes] CHECK CONSTRAINT [FK_nodeattr_node]
GO
ALTER TABLE [dbo].[node_docs]  WITH CHECK ADD  CONSTRAINT [FK_nodedoc_doctype] FOREIGN KEY([doctypeid])
REFERENCES [dbo].[doc_type] ([doctypeid])
GO
ALTER TABLE [dbo].[node_docs] CHECK CONSTRAINT [FK_nodedoc_doctype]
GO
ALTER TABLE [dbo].[node_docs]  WITH CHECK ADD  CONSTRAINT [fk_nodedoc_nodes] FOREIGN KEY([nodeid])
REFERENCES [dbo].[nodes] ([nodeid])
GO
ALTER TABLE [dbo].[node_docs] CHECK CONSTRAINT [fk_nodedoc_nodes]
GO
ALTER TABLE [dbo].[node_membership]  WITH CHECK ADD  CONSTRAINT [FK_nodemembership_group] FOREIGN KEY([groupnode_id])
REFERENCES [dbo].[nodes] ([nodeid])
GO
ALTER TABLE [dbo].[node_membership] CHECK CONSTRAINT [FK_nodemembership_group]
GO
ALTER TABLE [dbo].[node_membership]  WITH CHECK ADD  CONSTRAINT [FK_nodemembership_member] FOREIGN KEY([membernode_id])
REFERENCES [dbo].[nodes] ([nodeid])
GO
ALTER TABLE [dbo].[node_membership] CHECK CONSTRAINT [FK_nodemembership_member]
GO
ALTER TABLE [dbo].[node_membership]  WITH CHECK ADD  CONSTRAINT [FK_nodemembership_type] FOREIGN KEY([memtypeid])
REFERENCES [dbo].[membership_types] ([memtypeid])
GO
ALTER TABLE [dbo].[node_membership] CHECK CONSTRAINT [FK_nodemembership_type]
GO
ALTER TABLE [dbo].[nodes]  WITH CHECK ADD  CONSTRAINT [FK_node_nodetypes] FOREIGN KEY([typeid])
REFERENCES [dbo].[nodetypes] ([typeid])
GO
ALTER TABLE [dbo].[nodes] CHECK CONSTRAINT [FK_node_nodetypes]
GO
ALTER TABLE [dbo].[process_docs]  WITH CHECK ADD  CONSTRAINT [FK_processdoc_doctype] FOREIGN KEY([doctypeid])
REFERENCES [dbo].[doc_type] ([doctypeid])
GO
ALTER TABLE [dbo].[process_docs] CHECK CONSTRAINT [FK_processdoc_doctype]
GO
ALTER TABLE [dbo].[process_docs]  WITH CHECK ADD  CONSTRAINT [fk_processdoc_process] FOREIGN KEY([processid])
REFERENCES [dbo].[processes] ([processid])
GO
ALTER TABLE [dbo].[process_docs] CHECK CONSTRAINT [fk_processdoc_process]
GO
ALTER TABLE [dbo].[process_membership]  WITH CHECK ADD  CONSTRAINT [FK_processmembership_edge] FOREIGN KEY([processedge_id])
REFERENCES [dbo].[edges] ([edgeid])
GO
ALTER TABLE [dbo].[process_membership] CHECK CONSTRAINT [FK_processmembership_edge]
GO
ALTER TABLE [dbo].[process_membership]  WITH CHECK ADD  CONSTRAINT [FK_processmembership_process] FOREIGN KEY([processid])
REFERENCES [dbo].[processes] ([processid])
GO
ALTER TABLE [dbo].[process_membership] CHECK CONSTRAINT [FK_processmembership_process]
GO
ALTER TABLE [dbo].[process_membership]  WITH CHECK ADD  CONSTRAINT [FK_processmembership_type] FOREIGN KEY([memtypeid])
REFERENCES [dbo].[membership_types] ([memtypeid])
GO
ALTER TABLE [dbo].[process_membership] CHECK CONSTRAINT [FK_processmembership_type]
GO
ALTER TABLE [dbo].[processes]  WITH CHECK ADD  CONSTRAINT [FK_process_fromnode] FOREIGN KEY([from_node])
REFERENCES [dbo].[nodes] ([nodeid])
GO
ALTER TABLE [dbo].[processes] CHECK CONSTRAINT [FK_process_fromnode]
GO
ALTER TABLE [dbo].[processes]  WITH CHECK ADD  CONSTRAINT [FK_process_tonode] FOREIGN KEY([to_node])
REFERENCES [dbo].[nodes] ([nodeid])
GO
ALTER TABLE [dbo].[processes] CHECK CONSTRAINT [FK_process_tonode]
GO
ALTER TABLE [dbo].[processes]  WITH CHECK ADD  CONSTRAINT [FK_process_type] FOREIGN KEY([edgetypeid])
REFERENCES [dbo].[edgetypes] ([edgetypeid])
GO
ALTER TABLE [dbo].[processes] CHECK CONSTRAINT [FK_process_type]
GO
