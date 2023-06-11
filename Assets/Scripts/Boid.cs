using UnityEngine;

public class Boid : MonoBehaviour
{

    //https://blog.yarsalabs.com/flock-simulation-using-boids-in-unity/
    private BoidManager boidManager;
    private Vector3 direction;


    private void Awake()
    {
        direction = new Vector3(Random.Range(2f, 4f), Random.Range(1f, 4f), Random.Range(3f, 4f));
        boidManager = transform.parent.GetComponent<BoidManager>();
    }

    
    void MoveToCenter()
    {
        Vector3 forward = Vector3.zero;
        float flockCount = 0;

        for (int i = 0; i < boidManager.transform.childCount ; i++)
        {
            Transform bird = boidManager.transform.GetChild(i);
            float distance = Vector3.Distance(bird.position, transform.position);
            if (distance <= boidManager.radiusCenter){
                forward += bird.transform.position;
                flockCount++;
            }
        }

        if (flockCount == 0) return;
        
        forward = (forward/flockCount).normalized;
        forward = (forward -  transform.position).normalized;
        float delta = boidManager.strenghtCenter * Time.deltaTime;
        direction +=  delta*forward/(delta+1);
        direction = direction.normalized;

    }
    
    void AvoidOther(){

        Vector3 forward = Vector2.zero;

        for (int i = 0; i < boidManager.transform.childCount; i++)
        {
            Transform bird = boidManager.transform.GetChild(i);
            float distance = Vector3.Distance(bird.transform.position, transform.position);
            
            if (distance <= boidManager.radiusAvoid){
                forward += (transform.position - bird.transform.position);
            }
        }
        forward = forward.normalized;

        direction += boidManager.strenghtAvoid*forward/(boidManager.strenghtAvoid +1);
        direction = direction.normalized;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void AlignWithOthers(){

        Vector3 forward = Vector3.zero;
        int flockCount = 0;

        
        for (int i = 0; i < boidManager.transform.childCount; i++)
        {
            Transform bird = boidManager.transform.GetChild(i);
            float distance = Vector3.Distance(bird.transform.position, transform.position);
            if (distance <= boidManager.radiusAlign){
                forward += bird.GetComponent<Boid>().direction;
                flockCount++;
            }
        }

        forward = (forward/flockCount).normalized;
        forward = (forward -  transform.position).normalized;
        
        float delta = boidManager.strenghtAlign * Time.deltaTime;
        direction +=  delta*forward/(delta+1);
        direction = direction.normalized;

    }
    
    void TowardsGoal () {
        Vector3 forward = Vector3.zero;
        float distance = Vector3.Distance(boidManager.goal.transform.position, transform.position);
        if (distance > boidManager.radiusGoal)
        {
            forward = ( boidManager.goal.transform.position - transform.position);
            forward = forward.normalized;

            direction += boidManager.strengthGoal*forward;
            direction = direction.normalized;
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        //TowardsGoal();
        AlignWithOthers();
        MoveToCenter();
        AvoidOther();
        //transform.Translate(direction * (boidManager.speed * Time.deltaTime));
        Vector3 forward = transform.position + direction * (boidManager.speed);
        transform.position = Vector3.Lerp(transform.position,forward,Time.deltaTime*2f);
    }
}
