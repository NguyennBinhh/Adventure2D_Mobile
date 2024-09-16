using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMovement : MonoBehaviour
{
    public Transform[] chainLinks; // Mảng chứa các đoạn xích
    public Transform ball; // Quả cầu
    public Transform anchorPoint; // Điểm treo
    public float linkLength = 0.5f; // Chiều dài mỗi đoạn xích

    void Update()
    {
        // Bắt đầu từ điểm treo và tính toán rotation cho mỗi đoạn xích
        Vector3 previousPosition = anchorPoint.position;

        for (int i = 0; i < chainLinks.Length; i++)
        {
            // Tính toán hướng từ đoạn xích hiện tại đến quả cầu
            Vector3 directionToBall = ball.position - previousPosition;

            // Điều chỉnh chiều dài đoạn xích
            directionToBall = directionToBall.normalized * linkLength;

            // Cập nhật vị trí đoạn xích
            chainLinks[i].position = previousPosition + directionToBall;

            // Tính toán rotation để đoạn xích hướng về quả cầu
            chainLinks[i].up = directionToBall;

            // Cập nhật vị trí cho đoạn xích tiếp theo
            previousPosition = chainLinks[i].position;
        }

        // Cập nhật vị trí của quả cầu
        ball.position = previousPosition;
    }
}
