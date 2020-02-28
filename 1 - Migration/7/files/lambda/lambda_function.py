import json
import boto3
import json

DYNAMODB_TABLE = "YOUR-TABLE-NAME"
dynamodbclient = boto3.client('dynamodb')

def lambda_handler(event, context):
    print(json.dumps(event))
    http_method = event.get('httpMethod')
    if (http_method == 'GET'):
        path = event.get('path')
        if path == '/api/Ticket':
            tickets = get_tickets()
            response = {
                        "statusCode": 200,
                        "statusDescription": "200 OK",
                        "isBase64Encoded": False,
                        "headers": {
                            "Content-Type": "application/json; charset=utf-8",
                            "Access-Control-Allow-Origin" : "*"
                        }
                    }
            response['body'] = json.dumps(tickets)
            return response
        else:
            resource = event.get('resource')
            ticket_id = path.split('/')[3]
            
            print('TicketId:' + ticket_id)
            ticket = get_ticket(ticket_id)
            response = {
                        "statusCode": 200,
                        "statusDescription": "200 OK",
                        "isBase64Encoded": False,
                        "headers": {
                            "Content-Type": "application/json; charset=utf-8",
                            "Access-Control-Allow-Origin" : "*"
                        }
                    }
            response['body'] = json.dumps(ticket)
            return response

def get_tickets():
    response = dynamodbclient.scan( TableName = DYNAMODB_TABLE)
    tickets = response.get('Items')
    # print(json.dumps(tickets))
    data = []
    for item in tickets:
        data.append(unmarshal_dynamodb_json(item))
    return data
    
def get_ticket(ticket_id):
        key = {
            'Id': {'S': ticket_id}
        }
        response = dynamodbclient.get_item( TableName = DYNAMODB_TABLE, Key = key)
        item = response.get('Item')
        # print(json.dumps(response))
        return unmarshal_dynamodb_json(item)


def unmarshal_dynamodb_json(node):
    data = dict({})
    data['M'] = node
    return _unmarshal_value(data)


def _unmarshal_value(node):
    if type(node) is not dict:
        return node
    # print(node)
    for key, value in node.items():
        # S – String - return string
        # N – Number - return int or float (if includes '.')
        # B – Binary - not handled
        # BOOL – Boolean - return Bool
        # NULL – Null - return None
        # M – Map - return a dict
        # L – List - return a list
        # SS – String Set - not handled
        # NN – Number Set - not handled
        # BB – Binary Set - not handled
        key = key.lower()
        if key == 'bool':
            return value
        if key == 'null':
            return None
        if key == 's':
            return value
        if key == 'n':
            if '.' in str(value):
                return float(value)
            return int(value)
        if key in ['m', 'l']:
            if key == 'm':
                data = {}
                for key1, value1 in value.items():
                    if key1.lower() == 'l':
                        data = [_unmarshal_value(n) for n in value1]
                    else:
                        if type(value1) is not dict:
                            return _unmarshal_value(value)
                        data[key1] = _unmarshal_value(value1)
                return data
            data = []
            for item in value:
                data.append(_unmarshal_value(item))
            # print(data)
            return data