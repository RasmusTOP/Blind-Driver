#Navigation components

You add these to the 2D gameobjects in the scene to make the GPS system recognize them.

Roads have to get assigned the road component to make a difference
Offroad objects have the offroad component.

In order for GPS to avoid obstacles you gotta add the Obstacle component to your obstacles.

#The required BoxCollider2D sets the size of the actual object within the navigation system (in case of obstacles also in the corporeal world)

If Offroad and Road objects are layered then Roads take precedence.

#Target should be placed on an empty gameobject and it's coord will indicate where the driver should go.
