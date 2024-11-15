using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class AVLTree
    {
        public AVLTree() 
        {

        }
        // Root for AVL Tree
        public AVLNode avlRoot;
        public void InsertServiceRequestAVL(ServiceRequest request)
        {
            avlRoot = InsertNodeAVL(avlRoot, request);
        }

        public AVLNode InsertNodeAVL(AVLNode node, ServiceRequest request)
        {
            if (node == null)
                return new AVLNode(request);

            if (string.Compare(request.UUID, node.Data.UUID) < 0)
                node.Left = InsertNodeAVL(node.Left, request);
            else if (string.Compare(request.UUID, node.Data.UUID) > 0)
                node.Right = InsertNodeAVL(node.Right, request);

            // Update the height of the ancestor node
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Get the balance factor
            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && string.Compare(request.UUID, node.Left.Data.UUID) < 0)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && string.Compare(request.UUID, node.Right.Data.UUID) > 0)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && string.Compare(request.UUID, node.Left.Data.UUID) > 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && string.Compare(request.UUID, node.Right.Data.UUID) < 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }
        public int GetHeight(AVLNode node)
        {
            return node == null ? 0 : node.Height;
        }

        public int GetBalance(AVLNode node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        public AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        public AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }
        public void InOrderTraversalAVL(AVLNode node, Action<ServiceRequest> action)
        {
            if (node == null) return;
            InOrderTraversalAVL(node.Left, action);
            action(node.Data);
            InOrderTraversalAVL(node.Right, action);
        }

        public void SearchPartialUUID(AVLNode node, string partialUUID, Action<ServiceRequest> action)
        {
            SearchPartialUUIDHelper(node, partialUUID, action);
        }

        private void SearchPartialUUIDHelper(AVLNode node, string partialUUID, Action<ServiceRequest> action)
        {
            if (node == null)
                return;

            // If the UUID contains the substring, add it to results
            if (node.Data.UUID.Contains(partialUUID))
                action(node.Data);

            // Continue searching in both subtrees
            SearchPartialUUIDHelper(node.Left, partialUUID, action);
            SearchPartialUUIDHelper(node.Right, partialUUID, action);
        }
    }
}

