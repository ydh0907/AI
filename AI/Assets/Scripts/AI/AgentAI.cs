using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AgentAI : MonoBehaviour
{
    public List<AIInput> inputs;
    public List<AIOutput> outputs;

    public bool simulate = false;
    public AISeedSO rootSeed;
    public AISeedSO randSeed;

    private void Awake()
    {
        inputs = GetComponentsInChildren<AIInput>().ToList();
        outputs = GetComponentsInChildren<AIOutput>().ToList();

        if (rootSeed.seeds.Count != outputs.Count)
            rootSeed.seeds = new List<Vector3>(outputs.Count);
    }

    public void Simulation()
    {
        simulate = true;
        randSeed = Instantiate(rootSeed);

        for (int i = 0; i < randSeed.seeds.Count; i++)
        {
            randSeed.seeds[i] += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        }
    }

    public void Stop()
    {
        simulate = false;

        randSeed.priority = Vector3.Distance(Vector3.zero, transform.position);

        if (randSeed.priority >= rootSeed.priority)
            rootSeed = randSeed;

        transform.position = Vector3.up;
    }

    private void Update()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            inputs[i].Execute(this);
        }
        for (int i = 0; i < outputs.Count; i++)
        {
            outputs[i].Execute(randSeed.seeds[i]);
        }
    }
}

public class AILearn
{

}