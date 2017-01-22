

function adjacencyToNodeLinks(adjlist) {
    var container = {};
    var nodes = [];
    var links = [];
    for (var i = 0; i < adjlist.entries.length; i++) {
        var node = {};
        var n = adjlist.entries[i];
        node.id = 'Node-'+n.nodeId;
        node.group = node.id;
        nodes.push(node);
        var edges = n.connections;
        for (var j = 0; j < edges.length; j++) {
            var link = {};
            var src = n.nodeId;
            var tgt = edges[j];
            if (src && tgt) {
                link.source = 'Node-'+src;
                link.target = 'Node-'+tgt;
                link.value = 1;
                link.weight = 1;
                links.push(link);
            }

        }
    }
    container.nodes = nodes;
    container.links = links;
    return container;
}