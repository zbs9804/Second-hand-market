import { Container, Divider, Paper, Typography } from "@mui/material";
import { useLocation } from "react-router-dom";

//redirect user to this component when server error occured
export default function ServerError() {
    const {state} = useLocation();

    return (
        <Container component={Paper}>
            {state?.error ? (
                <>
                    <Typography gutterBottom variant="h3" color='secondary'>
                            {state.error.title}
                    </Typography>
                    <Divider />
                    <Typography variant="body1">{state.error.detail || 'Internal server error'}</Typography>
                </>
            ) : (
                <Typography gutterBottom variant='h5'>Server error</Typography>
            )}
        </Container>
    )
}