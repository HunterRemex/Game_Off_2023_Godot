extends Area2D


@export var moveSpeed = 350;
@export var characterSprite: AnimatedSprite2D;
var velocity = Vector2.ZERO;
var screenSize = Vector2(720, 720);

const chrAnimIdle = "idle";
const chrAnimRun = "run";
const chrAnimHurt = "hurt";
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	MovePlayer(delta);
	UpdateSprite(velocity);
	pass;

func MovePlayer(delta):
	velocity = Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down");
	position += velocity * moveSpeed * delta;
	
	#Clamp position to screen, Origin at top left
	position.x = clamp(position.x, 0, screenSize.x);
	position.y = clamp(position.y, 0, screenSize.y);
	return velocity;
	pass;
	
func UpdateSprite(velocity):
	if (velocity.length() > 0):
		characterSprite.animation = chrAnimRun;
	else:
		characterSprite.animation = chrAnimIdle;
	if (velocity.x != 0):
		characterSprite.flip_h = sign(velocity.x) < 0