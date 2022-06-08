extends Node

onready var global_data = get_node("/root/GlobalData")

export var GOT_THE_JOB = "Congrats! You got the job!"
export var NO_JOB_AVAILABLE = "Sorry but this job is not available."
export var NOT_ENOUGH_EXPERIENCE = "You do not have enough experience for this job!"
export var NOT_ENOUGH_EDUCATION = "You do not have enough education for this job!"
export var NEW_LOW_COST_APARTMENT = "We'll get you a key right away! And we'll even scrub that spot on the carpet!!"
export var RENTING_LOW_COST_APARTMENT = "You're already renting a Low Cost Apartment!"
export var RENTING_LE_SECURITY_APARTMENT = "But Sir! We have already prepared your bubble bath in your Le Security apartment!"
export var NEW_LE_SECURITY_APARTMENT = "Please step this way so you can know what money smells like!"
export var RENT_PAYED = "Thank you for paying your rent! Now we won't have to send the dogs."
export var NO_MONEY_TO_PAY_RENT = "You ain't got no monies!"
export var NOT_ENOUGH_MONEY = "Sorry you seem to be a bit short on monies!"
export var RENTAL_OFFICE_CLOSED = "Closed!"
export var SECURITY_DEPOSIT_PAYED_FIRST = "You must pay your security deposit for the month first!"
export var EXTEND_RENT = "Sure you can pay your rent next week!"
export var RENT_EXTENDED_MAX = "You've already got 2 weeks extension!"
export var REJECTED_EXTENDING_RENT = "Sorry but I need you to pay now."

export var RENTAL_OFFICE_OPEN = [
	"Welcome to another beautiful day at your caring Rental Office", 
	"Hi! Finally here to pay the rent?!", "Hello? Oh Hi! Got my monies?!"
]
export var LOW_COST_APARTMENT_HOME_GREET = [
	"Ahh, home sweet BLAAARGH!!", 
	"Oh! Hey! There's that banana I've been missing!", 
	"Oh...rats!"
]
export var LOW_COST_APARTMENT_VISITOR_GREET = [
	"Well that's just something special! Vomit colored doormats?", 
	"I wonder why they call it Low Cost...ooooh!", "Oh...rats!"
]
export var JOBS_RESULTS_GREET = [
	"Looking for a little something new today?", 
	"Would you like a side of fries with that?", 
	"Have you consided maybe just lounging around all day?"
]

export var PAWN_SHOP_GREET = [
	"Down there at the pawn shop, it's the way-only way to shop.",
	"Down there at the pawn shop, if it's not in stone",
	"Down there at the pawn shop, it no way, no way to shop"
]

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func get_random_message(val):
	return val[global_data.get_rand_between(0, val.size() - 1)]
