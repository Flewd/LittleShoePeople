import UnityEngine

class CreditsScript (MonoBehaviour): 

	def Start ():
		pass
	
	def Update ():
		transform.Translate((Vector3.up * 50 * Time.deltaTime), Space.World)

