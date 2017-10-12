using System.Collections.Generic;

namespace Chapter09
{
    public class PathNode {
    	public Person Person {get; private set;}
    	private PathNode previousNode = null;
    	public PathNode(Person p, PathNode previous) {
    		Person = p;
    		previousNode = previous;
    	}
        
    	public LinkedList<Person> Collapse(bool startsWithRoot) {
    		LinkedList<Person> path = new LinkedList<Person>();
    		PathNode node = this;
    		while (node != null) {
    			if (startsWithRoot) {
    				path.AddLast(node.Person);
    			} else {
    				path.AddFirst(node.Person);
    			}
    			node = node.previousNode;
    		}
    		return path;
    	}
    }
}


